using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static int score = 0;
    
    public void OnGUI()
    {
        Rect scoreRect = new Rect(0, 0, 100, 30);
        GUI.Box(scoreRect, "" + score);
    }

    public void RemovePoints(int amount)
    {
        score -= amount;
    }
}
