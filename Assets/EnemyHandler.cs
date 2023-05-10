using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public GameObject coin;
    public GameObject shaker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDeath(int scoreToAdd, GameObject deathEffect, Vector3 position, int chanceOfCoinDrop)
    {
        //Call TriggerShake() from CameraShake script
                shaker = GameObject.Find("MainCamera");
                shaker.GetComponent<CameraShake>().TriggerShake();
                
                ScoreScript.AddScore(scoreToAdd);
                if(Random.Range(0, chanceOfCoinDrop) == 0)
                {
                    GameObject coinObject = Instantiate(coin, transform.position, Quaternion.identity);
                    //Delete the coin after 20 seconds
                    Destroy(coinObject, 20f);
                }

                GameObject deathEffectObject = Instantiate(deathEffect, position, Quaternion.identity);
                
                Destroy(deathEffectObject, 3f);
    }
}
