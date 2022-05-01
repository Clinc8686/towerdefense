using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnPointEnemy;
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(0));
        StartCoroutine(ExecuteAfterTime(1));
        StartCoroutine(ExecuteAfterTime(2));
        StartCoroutine(ExecuteAfterTime(3));
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
