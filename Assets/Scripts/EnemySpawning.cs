using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A script that spawns the enemy prefab at a random position on the screen every X seconds within a certain range of the player and a minimum distance from the player
public class EnemySpawning : MonoBehaviour
{
    public GameObject basicEnemyPrefab;
    public GameObject throwerEnemyPrefab;
    public GameObject bossEnemyPrefab;

    public float spawnRate = 2f;
    float nextSpawn = 0f;
    public float spawnDistance = 10f;
    public float minDistance = 5f;
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        // check if player is killed and if so, stop spawning enemies
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            // increase spawn rate over time exponentially
            if(Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                spawnRate *= 0.99f;
                SpawnBasicEnemy();
                // 1/3 chance to also spawn a thrower enemy
                if(Random.Range(0, 3) == 0)
                {
                    SpawnThrowerEnemy();
                }
            }
        } 
    }

    void SpawnBasicEnemy()
    {
        // spawn enemy at a random position within a certain range of the player and a minimum distance from the player
        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance;
        while(Vector2.Distance(spawnPosition, player.position) < minDistance)
        {
            spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance;
        }
        Instantiate(basicEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnThrowerEnemy()
    {
        // spawn enemy at a random position within a certain range of the player and a minimum distance from the player
        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance;
        while(Vector2.Distance(spawnPosition, player.position) < minDistance)
        {
            spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance;
        }
        Instantiate(throwerEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
