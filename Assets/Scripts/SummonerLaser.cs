using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerLaser : MonoBehaviour {

    public Transform player;
    public GameObject SummonerEnemy;
    public float killTime = 0.5f;
    public Vector2 centerOfObject;
    public float radius = 3;

    public int attackRange = 40;
    

    public GameObject hitEffect;


    void Start()
    {
        // set player transform to player object
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

    }


    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null) {
            // if time is more than the time to fire
            if (Time.time > killTime) {

                Debug.Log("Time.time = " + Time.time);
                killTime = Time.time + killTime;
                centerOfObject = new Vector2(transform.position.x, transform.position.y);
                Invoke("fire", killTime);
            }
        }
    }

    void fire() {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //if player is within the radius, then destroy the player
        if (Vector2.Distance(transform.position, player.position) < radius) {
            Destroy(player.gameObject);
            //enable game over menu by finding the game over menu object and setting its child to active
            GameObject gameOverMenu = GameObject.Find("GameOverMenu");
            gameOverMenu.transform.GetChild(0).gameObject.SetActive(true);
        }
        Destroy(effect, 2f);
        Destroy(gameObject);



    }

}   