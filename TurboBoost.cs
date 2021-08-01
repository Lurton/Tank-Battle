using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboBoost : MonoBehaviour
{
    public CharacterController controller;

    public float boostSpeed = 50;
    public float boostLength = 5;
    public float startTime = -1;

    public void OnGUI()
    {
        Rect turboRect = new Rect(10, Screen.height - 250, 75, 75);
        if (GUI.Button(turboRect, "Turbo"))
        StartBoost();
    }

    public void StartBoost()
    {
        if (startTime < 0)
            startTime = Time.time;
    }

    public void Update()
    {
        if (startTime < 0) return;
        if (controller == null) return;

        controller.Move(controller.transform.forward * boostSpeed * Time.deltaTime);

        if (Time.time - startTime < 0.5f)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 130, (Time.time - startTime) * 2);
        else if (Time.time - startTime > boostLength - 0.5f)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, (Time.time - startTime - boostLength + 0.5f) * 2);

        if(Time.time > startTime + boostLength)
        {
            startTime = -1;
        }
    }
}
