using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject[] waypoints;
    private float radius = 0.1f;
    private int current = 0;
    private float speed = 1.5f;
    private WaypointManager wpm;
    
    void Start()
    {
        wpm = GameObject.Find("Waypoints").GetComponent<WaypointManager>();
        waypoints = wpm.waypoints;
    }

    void Update()
    {
        
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < radius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
                Destroy(enemyPrefab);
            }
            transform.LookAt(waypoints[current].transform.position);
            transform.Rotate(Vector3.up * 270);
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position,
            Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        Destroy(this.gameObject);
    }
}
