using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private float spawnFrequency;
    [SerializeField] private Vector2 xOffsetMinMax;
    [SerializeField] private List<Enemy> enemies;

    private void Start()
    {
        //StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnFrequency);
            Vector3 spawnPos = new Vector3(enemySpawnPoint.position.x + Random.Range(xOffsetMinMax.x, xOffsetMinMax.y), enemySpawnPoint.position.y, enemySpawnPoint.position.z);
            var obj = Instantiate(enemies[0], spawnPos, Quaternion.Euler(new Vector3(0,180,0)));
        }
    }
}
