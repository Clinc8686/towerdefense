using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceTower2 : MonoBehaviour
{
    public GameObject tower2;
    public static bool tower2Dragged;
    public void setTower2()
    {
        if (!tower2Dragged)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(mousePos);
            
            tower2 = Instantiate(tower2, new Vector3(cursorPosition.x, cursorPosition.y, 0), Quaternion.identity);
            tower2Dragged = true;
        }
    }

    private void Update()
    {
        if (tower2Dragged)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0);
        
            tower2.transform.position = cursorPosition;
        }
    }

    void OnLeftClick()
    {
        if (tower2Dragged && Tower1.collide == false)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0);

            tower2.transform.position = cursorPosition;
            tower2.GetComponent<LineRenderer>().enabled = false;
            Rigidbody2D tower = tower2.GetComponent<Rigidbody2D>();
            tower.constraints = RigidbodyConstraints2D.FreezeAll;
            tower2Dragged = false;
        }
    }
}
