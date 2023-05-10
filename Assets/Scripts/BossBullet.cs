using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //script that destroys the bullet prefab when it collides with another object
public GameObject hitEffect;

    

    //make the bullet disappear after 5 seconds
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (other.gameObject.tag == "Boss")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
        if(other.gameObject.tag != "Enemy" && other.gameObject.tag != "Boss") {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            effect.transform.localScale = new Vector3(0.2f, 0.2f, 1f);

            GameObject bossObject = GameObject.Find("BigNoseBoss");
            
  
            //rotate effect to towards the bossObject
            Vector3 target = bossObject.transform.position - effect.transform.position;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            effect.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));



            Destroy(effect, 0.4f);

            
        }
        
        // if the bullet hits a player then the player dies
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            //enable game over menu by finding the game over menu object and setting its child to active
            GameObject gameOverMenu = GameObject.Find("GameOverMenu");
            gameOverMenu.transform.GetChild(0).gameObject.SetActive(true);
        }

        // if the bullet hits a bullet then both bullets are destroyed
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }



        

    }
}
