using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnPointEnemy;
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            StartCoroutine(ExecuteAfterTime(i));
        }
    }
    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(enemyPrefab, new Vector3(spawnPointEnemy.transform.position.x, spawnPointEnemy.transform.position.y, spawnPointEnemy.transform.position.z), Quaternion.identity);

    }
    
    void Update()
    {

    }
}
