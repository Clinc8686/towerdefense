using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tower : MonoBehaviour
{
    public LineRenderer circleRenderer;
    private float CircleRadius = 3.5f;
    public static bool collide = false;
    public static int TowerLevel = 1;
    void Start()
    {
        circleRenderer.enabled = true;
        DrawCircle(100);
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        circleRenderer.startColor = Color.red;
        circleRenderer.endColor = Color.red;
        collide = true;
    }

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        circleRenderer.startColor = Color.red;
        circleRenderer.endColor = Color.red;
        collide = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        circleRenderer.startColor = new Color(220, 224, 0);
        circleRenderer.endColor = new Color(220, 224, 0);
        collide = false;
    }

    void DrawCircle(int steps)
    {
        switch (TowerLevel)
        {
            case 1:
                CircleRadius = 3.5f;
                break;
            case 2:
                CircleRadius = 4.5f;
                break;
        }
        circleRenderer.positionCount = steps;

        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float) currentStep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * CircleRadius;
            float y = yScaled * CircleRadius;

            Vector3 currentPosition = new Vector3(x, y, 0);
            circleRenderer.SetPosition(currentStep, currentPosition);
        }
    }

    public void TowerClicked()
    {
        Debug.Log("ja");
        this.GetComponent<LineRenderer>().enabled = true;
    }
}
