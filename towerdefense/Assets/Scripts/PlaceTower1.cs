using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceTower1 : MonoBehaviour
{
    public GameObject tower1;
    public static bool tower1Dragged;
    public void setTower1()
    {
        if (!tower1Dragged)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(mousePos);
            
            tower1 = Instantiate(tower1, new Vector3(cursorPosition.x, cursorPosition.y, 0), Quaternion.identity);
            tower1Dragged = true;
        }
    }

    private void Update()
    {
        if (tower1Dragged)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0);
        
            tower1.transform.position = cursorPosition;
        }
    }

    void OnLeftClick()
    {
        if (tower1Dragged && Tower1.collide == false)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0);

            tower1.transform.position = cursorPosition;
            tower1.GetComponent<LineRenderer>().enabled = false;
            Rigidbody2D tower = tower1.GetComponent<Rigidbody2D>();
            tower.constraints = RigidbodyConstraints2D.FreezeAll;
            tower1Dragged = false;
        }
    }
}
