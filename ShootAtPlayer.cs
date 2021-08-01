using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public Vector3 lastPosition = Vector3.zero;
    public float maxSpeed = 1f;

    public float readyLength = 2f;
    private float readyTime = -1;

    public float turretSpeed = 45f;

    public Transform turretPivot;
    public Transform muzzlePoint;

    public void Update()
    {
        if (CheckCanFire())
        {
            if(readyTime < 0)
            {
                PrepareFire();
            }
            else if(readyTime <= Time.time)
            {
                Fire();
            }
        }
        else
        {
            ClearFire();
            RotateTurret();
        }
    }

    public bool CheckCanFire()
    {
        float move = Vector3.Distance(lastPosition, transform.position);
        float speed = move / Time.deltaTime;

        lastPosition = transform.position;

        if (speed > maxSpeed) return false;

        Vector3 targetDir = PlayerPosition.position - turretPivot.position;

        targetDir.y = 0;

        float angle = Vector3.Angle(targetDir, turretPivot.forward);

        return angle < 0.1f;
    }

    public void PrepareFire()
    {
        readyTime = Time.time + readyLength;
    }

    public void Fire()
    {
        if (muzzlePoint == null) return;

        RaycastHit hit;
        if(Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out hit))
        {
            hit.transform.gameObject.SendMessage("RemovePoints", 3, SendMessageOptions.DontRequireReceiver);
        }
        ClearFire();
    }

    public void ClearFire()
    {
        readyTime = -1;
    }

    public void RotateTurret()
    {
        if (turretPivot == null) return;

        Vector3 targetDir = PlayerPosition.position - turretPivot.position;
        targetDir.y = 0;

        float step = turretSpeed * Time.deltaTime;

        Vector3 rotateDir = Vector3.RotateTowards(turretPivot.forward, targetDir, step, 0);

        turretPivot.rotation = Quaternion.LookRotation(rotateDir);
    }
}
