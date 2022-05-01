using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceTower : MonoBehaviour
{
    public GameObject tower;
    public static bool towerDragged;
    public void placeTower()
    {
        if (!towerDragged)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(mousePos);
            
            tower = Instantiate(tower, new Vector3(cursorPosition.x, cursorPosition.y, 0), Quaternion.identity);
            towerDragged = true;
        }
    }

    private void Update()
    {
        if (towerDragged)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0);
        
            tower.transform.position = cursorPosition;
        }
    }

    void OnLeftClick(InputAction.CallbackContext context)
    {
        if (towerDragged && Tower.collide == false)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 cursorPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0);

            tower.transform.position = cursorPosition;
            tower.GetComponent<LineRenderer>().enabled = false;
            Rigidbody2D towerrb = tower.GetComponent<Rigidbody2D>();
            towerrb.constraints = RigidbodyConstraints2D.FreezeAll;
            towerDragged = false;
        }
    }
}
