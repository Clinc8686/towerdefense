using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooting2 : MonoBehaviour
{
    public GameObject projectileSpawn;
    public GameObject projectile;
    private float radius = 4.5f;
    private float projectileSpeed = 3.0f;
    private float latestShooting = 0.0f;
    private float duration = 0.5f;
    void Start()
    {
        
    }
    
    void Update()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null && PlaceTower2.tower2Dragged != true)
        {
            if (Vector2.Distance(enemy.GetComponent<PolygonCollider2D>().ClosestPoint(transform.position), transform.position) < radius)
            {
                float zAngle = Mathf.Atan2(transform.position.y - enemy.transform.position.y,
                    transform.position.x - enemy.transform.position.x);
                float zAngleDegrees = (180 / Mathf.PI) * zAngle;
                transform.rotation = Quaternion.Euler(0,0,zAngleDegrees+90);
                //Debug.Log("got him!");
                Shoot(enemy);
            }
        }
    }

    void Shoot(GameObject enemy)
    {
        latestShooting += Time.deltaTime;
        if (latestShooting >= duration)
        {
            /*GameObject ShootedProjectile = Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
            ShootedProjectile.transform.Rotate(0,0,180);*/

            GameObject ShootedProjectile = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            ShootedProjectile.transform.Rotate(0,0,0);
            Rigidbody2D rb = ShootedProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(projectileSpawn.transform.up * 20, ForceMode2D.Impulse);

            Destroy(ShootedProjectile, 10.0f);
            latestShooting = 0.0f;
        }
    }
}
