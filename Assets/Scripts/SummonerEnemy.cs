using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerEnemy : MonoBehaviour
{

    public Transform player;    
    public GameObject coin;
    public Transform firePoint;
    

    public GameObject shootEffect;
    public GameObject SummonerLaser;
    public GameObject deathEffect;


    public int attackRange = 40;
    public float attackSpeed = 3f;
    public int scoreToAdd = 3;

    public int health = 5;
    //add health

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null) {
            if (Vector2.Distance(transform.position, player.position) < attackRange) {
                if (Time.time > attackSpeed) {
                    attackSpeed = Time.time + attackSpeed;
                    Shoot();
                }
            }
        } else {
            transform.Rotate(0, 0, 100 * Time.deltaTime);
        }
        
    }

    void Shoot() {
        // spawns laser on the player

        GameObject effect = Instantiate(shootEffect, firePoint.position, Quaternion.identity);
        //set parent of effect to current object
        effect.transform.parent = transform;


        GameObject laser = Instantiate(SummonerLaser, player.position, Quaternion.identity);
        Destroy(effect, 5f);
    }


    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().KillPlayer();
        }

        if(other.gameObject.tag == "Bullet")
        {
            if (health > 0) {
                health -= 1;
            } else {
                Destroy(gameObject);
                Destroy(other.gameObject);

                //Hi Connor, I added a EnemyHandler script on the GameManager object that easily handles enemy death. This will make it so you can allow coins to get removed a lot easier and do it once instead of
                //once for every enemy. I also just increased the health of this guy by like 2 but thats it.
                GameObject.Find("GameManager").GetComponent<EnemyHandler>().EnemyDeath(scoreToAdd, deathEffect, transform.position, 3);
            }
            
        }
    }

}
