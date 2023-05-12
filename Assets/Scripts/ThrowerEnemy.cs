using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//An enemy script based off of the Enemy script, but has ranged attacks
public class ThrowerEnemy : MonoBehaviour
{
    public float speed = 3f;
    public float attackSpeed = 2f;

    public float stoppingDistance = 4f;
    public float retreatDistance = 1f;
    public float attackRange = 15f;
    public float bulletSpeed = 5f;
    public int scoreToAdd = 3;

    public Transform player;
    public GameObject playerObject;
    public Transform firePoint;

    public GameObject coin;
    public GameObject enemyBullet;

    public GameObject shaker;

    public GameObject deathEffect;

    public int health = 2;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // set speed to a random value between 1 and speed
        speed = Random.Range(1f, speed);
        // set attack speed to a random value between 1 and attack speed
        attackSpeed = Random.Range(1f, attackSpeed);

    }

    void Update()
    {
        // check if player is killed and if so, stop moving towards player
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
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


            // if the player is within attack range, shoot a bullet at the player
            if(Vector2.Distance(transform.position, player.position) < attackRange)
            {
            
                // check for attack speed
                if(Time.time > attackSpeed)
                {
                    attackSpeed = Time.time + attackSpeed;
                    Shoot();
                }
            }

            //rotate to face player
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

            


        } else
        {
            //spin in place when player is dead/deleted
            transform.Rotate(0, 0, 100 * Time.deltaTime);
        }

        
        
    }

    public void Shoot()
    {
        // create a bullet and set its velocity to the direction of the player
        GameObject bullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = (player.position - transform.position).normalized * bulletSpeed;
    }

    // handles collisions with the player and bullets
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().KillPlayer(); 
        }

        if(other.gameObject.tag == "Bullet")
        {
            //check if health is 0, if so, destroy the enemy
            if(health <= 0)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);

                GameObject.Find("GameManager").GetComponent<EnemyHandler>().EnemyDeath(scoreToAdd, deathEffect, transform.position, 3);
                


            } else {
                //decrement health
                health--;
                //Destroy bullet
                Destroy(other.gameObject);
            }
        }
    }

}
