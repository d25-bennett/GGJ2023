using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 10.0f;
    public float spawnRadius = 5.0f;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
        spawnPos += (Vector2)player.position;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
