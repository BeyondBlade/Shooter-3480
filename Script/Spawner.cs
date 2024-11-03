using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyType1Prefab;
    public GameObject enemyType2Prefab;
    public float spawnRateType1 = 2f;
    public float spawnRateType2 = 3f;

    private float nextSpawnTimeType1;
    private float nextSpawnTimeType2;

    void Update()
    {
        if (Time.time > nextSpawnTimeType1)
        {
            nextSpawnTimeType1 = Time.time + spawnRateType1;
            SpawnEnemy(enemyType1Prefab);
        }

        if (Time.time > nextSpawnTimeType2)
        {
            nextSpawnTimeType2 = Time.time + spawnRateType2;
            SpawnEnemy(enemyType2Prefab);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 5f, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
