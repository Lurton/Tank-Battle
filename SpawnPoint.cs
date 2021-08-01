using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject tankPrefab;
    private GameObject currentTank;

    public float minPlayerDistance = 10;

    public void FixedUpdate()
    {
        if (CanSpawn())
        {
            SpawnTank();
        }
    }

    public bool CanSpawn()
    {
        if (currentTank != null) return false;

        float currentDistance = Vector3.Distance(PlayerPosition.position, transform.position);
        
        return currentDistance > minPlayerDistance;
    }

    public void SpawnTank()
    {
        if (tankPrefab == null) return;

        currentTank = Instantiate(tankPrefab) as GameObject;
        currentTank.transform.position = transform.position;
    }
}
