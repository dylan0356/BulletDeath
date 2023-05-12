using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningRoom : MonoBehaviour
{

    public GameObject[] enemies;

    //Size of the current room
    public float roomWidth = 30f;
    public float roomHeight = 30f;

    //Number of enemies to spawn
    public static int numberOfEnemies = 10;

    public bool isPlayerInRoom = false;

    public int enemiesLeft;


    // Start is called before the first frame update
    void Start(){

        
    }



    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Enemy"))
        {
            enemiesLeft -= 1;

            Debug.Log("Enemies left: " + enemiesLeft);
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemiesLeft = numberOfEnemies;

        //wait 1 second then call SpawnEnemies()
        SpawnEnemies();
        }
    }

    void SpawnEnemies() {
        //Spawn enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            //Randomly select an enemy from the enemies array
            GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Length)];

            //Get the current room position
            Vector3 roomPos = transform.position;

            //Randomly select a position within the room
            Vector3 spawnPos = new Vector3(roomPos.x + Random.Range(-roomWidth / 2, roomWidth / 2), roomPos.y + Random.Range(-roomHeight / 2, roomHeight / 2), 0);

            //Spawn the enemy
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        }
    }

}
