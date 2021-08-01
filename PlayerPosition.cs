using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPosition : MonoBehaviour
{
    public static Vector3 position = Vector3.zero;
    // Start is called before the first frame update
    public void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        position = transform.position;
    }
}
