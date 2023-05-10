using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNoseBoss : MonoBehaviour
{

    private int health = 100;
    public int scoreToAdd = 200;
    public int activateRange = 20;
    public float attackCooldown = 10f;

    public int bulletSpeed = 10;

    private bool bossActive = false;


    public GameObject deathEffect;
    public GameObject player;

    public GameObject laser;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if player is within range of the boss, activate the boss
        if(GameObject.FindGameObjectWithTag("Player") != null) {
            if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < activateRange) {
                ActivateBoss();
            }
        }

        if(bossActive)
        {
            //if attack cooldown is 0, attack
            if(attackCooldown <= 0)
            {
                Attack();
                attackCooldown = 3f;
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }
        }
    }

    void ActivateBoss()
    {
        bossActive = true;
    }

    void Attack()
    {
        //choose one of 5 different attack cases
        //int attackCase = Random.Range(0, 5);

        int attackCase = 1;
        switch(attackCase)
        {
            case 0:
                //create laser array to store lasers
                GameObject[] lasers = new GameObject[8];

                //create a loop to create 8 lasers and store them in the array but every loop rotate the angle by 45 degrees
                for(int i = 0; i < 8; i++)
                {
                    //create laser
                    lasers[i] = Instantiate(laser, transform.position, Quaternion.identity);
                    //rotate laser by 45 degrees
                    lasers[i].transform.Rotate(0, 0, 45 * i);
                }

                //for each laser in the array, destroy it after 1 second
                foreach(GameObject laser in lasers)
                {
                    Destroy(laser, 1f);
                }
                break;
            case 1:

                    //start the shoot coroutine
                    StartCoroutine(ShootCouroutine());
                
                
                break;
            case 2:
                Debug.Log("Attack case 2");
                break;
            case 3:
                Debug.Log("Attack case 3");
                break;
            case 4:
                Debug.Log("Attack case 4");
                break;
        }
    }

    IEnumerator ShootCouroutine() {

            for(int ii = 0; ii < 1; ii++) {

                for(int i = 0; i < 16; i++)
                {
                    //create bullet
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    //rotate bullet by 22.5 degrees
                    bullet.transform.Rotate(0, 0, 22.5f * i);
                    //make the bullet have a velocity of 20
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;

                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

                    //destroy bullet after 1 second
                    Destroy(bullet, 8f);

                    yield return new WaitForSeconds(0.1f);
                    }

                
            }
    }


                



    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            //get Player script from player and call KillPlayer function
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
                //get bullet damage
                int bulletDamage = other.gameObject.GetComponent<Bullet>().damage;
                //decrease health
                health -= bulletDamage;
            }
            
        }


    }
}
