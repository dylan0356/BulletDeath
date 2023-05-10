using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameHandler : MonoBehaviour
{

    public GameObject shaker;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*
    public void PlayerDeath(int Score, bool spawnCoin) 
    {
        Destroy(gameObject);
            Destroy(other.gameObject);

            //Call TriggerShake() from CameraShake script
            shaker = GameObject.Find("Main Camera");
            shaker.GetComponent<CameraShake>().TriggerShake();

            if (spawnCoin == true)
            {
                Instantiate(coin, transform.position, Quaternion.identity);
            }

            //add score
            ScoreScript.AddScore(Score);
    }*/
}
