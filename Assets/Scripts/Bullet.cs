using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //script that destroys the bullet prefab when it collides with another object
    public GameObject hitEffect;
    public GameObject effect;

    public int damage = 1;

    //instantiate a particle system 
    public ParticleSystem bulletParticle;

    void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag != "Player") {
            effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //set effect scale to 0.5
            effect.transform.localScale = new Vector3(0.2f, 0.2f, 1f);

            GameObject player = GameObject.Find("Player");
            
            //rotate effect to towards the player
            Vector3 target = player.transform.position - effect.transform.position;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            effect.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Destroy(effect, 1f);
            
        }
        

        // if the bullet has tag EnemyBullet and collides with the player, the player dies
        if(other.gameObject.tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            //enable game over menu by finding the game over menu object and setting its child to active
            GameObject gameOverMenu = GameObject.Find("GameOverMenu");
            gameOverMenu.transform.GetChild(0).gameObject.SetActive(true);
        }

        
    }

    //make the bullet disappear after 5 seconds
    void Start()
    {


        Destroy(gameObject, 5f);
        
        //set the bulletprefab to the current material

    }

    void Update() {
        //fade out the effect over 3 seconds



    }
}
