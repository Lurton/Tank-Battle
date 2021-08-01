using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (agent == null) return;

        agent.SetDestination(PlayerPosition.position);
    }
}
