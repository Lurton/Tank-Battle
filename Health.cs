using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    public void Hit()
    {
        health--;

        if(health <= 0)
        {
            Destroy(gameObject);
            ScoreCount.score += 5;
        }
    }
}
