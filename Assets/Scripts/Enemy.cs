using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// A script that makes the enemy go towards the player and if they collide, the player dies
public class Enemy : MonoBehaviour

{
    public float speed = 3f;
    public float stoppingDistance = 1f;
    public float retreatDistance = 1f;

    //Make it so the enemy has a max follow distance
    public float maxFollowDistance = 20f;

    public Transform player;
    public GameObject playerObject;

    public int scoreToAdd = 3;


    public int health = 3;

    public GameObject deathEffect;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // set speed to a random value between 1 and speed
        speed = Random.Range(1f, speed);
    }

    void Update()
    {
        // check if player is killed and if so, stop moving towards player
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
                //check if the player is within the max follow distance
                if(Vector2.Distance(transform.position, player.position) < maxFollowDistance)
                {
                    //move towards the player

                if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            } else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            } else {
                // walk around randomly
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            } 
        }
        else
            {
                //spin in place
                transform.Rotate(0, 0, 100 * Time.deltaTime);
            }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().KillPlayer();
        }

        if(other.gameObject.tag == "Bullet")
        {
            //Check if health is 0
            if(health <= 0)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);

                //Call enemyDeath function from EnemyHandler on GameManager object
                GameObject.Find("GameManager").GetComponent<EnemyHandler>().EnemyDeath(scoreToAdd, deathEffect, transform.position, 3);


            } else {
                //decrease health
                health--;
            }
            
        }
    }






}

