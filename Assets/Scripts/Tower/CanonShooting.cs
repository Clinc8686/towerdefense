using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooting : MonoBehaviour
{
    public GameObject projectileSpawnLevel1;
    public GameObject projectileSpawnLevel2;
    public GameObject projectileLevel1;
    public GameObject projectileLevel2;
    private GameObject Canon;
    private GameObject[] enemies;
    private float radius = 4.5f;
    private float projectileSpeed = 20.0f;
    private float latestShooting = 0.0f;
    private float duration = 0.5f;
    void Start()
    {
        Canon = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }
    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemies != null)
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null /*&& PlaceTower.towerDragged != true*/)
                {
                    if (Vector2.Distance(enemy.GetComponent<PolygonCollider2D>().ClosestPoint(Canon.transform.position), Canon.transform.position) < radius)
                    {
                        //Das hier ist noch uncool gelöst
                        switch (Tower.TowerLevel)
                        {
                            case 1:
                                Canon = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                                break;
                            case 2:
                                Canon = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                                break;
                        }
                
                        float zAngle = Mathf.Atan2(Canon.transform.position.y - enemy.transform.position.y,
                            Canon.transform.position.x - enemy.transform.position.x);
                        float zAngleDegrees = (180 / Mathf.PI) * zAngle;
                        Canon.transform.rotation = Quaternion.Euler(0,0,zAngleDegrees+90);
                        Shoot(enemy);
                    }
                }
            }
        }
    }

    void Shoot(GameObject enemy)
    {
        latestShooting += Time.deltaTime;
        if (latestShooting >= duration)
        {
            //Das hier ist noch uncool gelöst
            GameObject projectile = null;
            GameObject projectileSpawn = null;
            switch (Tower.TowerLevel)
            {
                case 1:
                    projectile = projectileLevel1;
                    projectileSpawn = projectileSpawnLevel1;
                    break;
                case 2:
                    projectile = projectileLevel2;
                    projectileSpawn = projectileSpawnLevel2;
                    break;
            }

            GameObject ShootedProjectile = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            ShootedProjectile.transform.Rotate(0,0,0);
            Rigidbody2D rb = ShootedProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(projectileSpawn.transform.up * projectileSpeed, ForceMode2D.Impulse);

            Destroy(ShootedProjectile, 10.0f);
            latestShooting = 0.0f;
        }
    }
}
