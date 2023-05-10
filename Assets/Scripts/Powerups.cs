using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// handles the powerups
// When a player kills an enenmy, there is a chance that the enemy will drop a powerup
public class Powerups : MonoBehaviour
{
    /* disabled
    public GameObject[] powerups; // array of powerups

    public float chanceToSpawn = 2f; // chance to spawn a powerup

    public bool isDoublePointsActive = false; // boolean to check if double points is active
    public bool isInvincibleActive = false; // boolean to check if invincibility is active
    public bool isSpeedActive = false; // boolean to check if speed is active
    public bool isDoubleMoneyActive = false; // boolean to check if double money is active

    public float doublePointsTime = 5f; // time that double points is active
    public float invincibleTime = 5f; // time that invincibility is active
    public float speedTime = 5f; // time that speed is active
    public float doubleMoneyTime = 5f; // time that double money is active

    public float doublePointsTimer = 0f; // timer for double points
    public float invincibleTimer = 0f; // timer for invincibility
    public float speedTimer = 0f; // timer for speed
    public float doubleMoneyTimer = 0f; // timer for double money

    public float doublePointsMultiplier = 2f; // multiplier for double points
    public float speedMultiplier = 2f; // multiplier for speed
    public float doubleMoneyMultiplier = 2f; // multiplier for double money

    public GameObject doublePointsUI; // double points UI
    public GameObject invincibleUI; // invincibility UI
    public GameObject speedUI; // speed UI
    public GameObject doubleMoneyUI; // double money UI

    public GameObject player; // player object

    public GameObject doublePointsSound; // double points sound
    public GameObject invincibleSound; // invincibility sound
    public GameObject speedSound; // speed sound
    public GameObject doubleMoneySound; // double money sound

    public GameObject doublePointsParticles; // double points particles
    public GameObject invincibleParticles; // invincibility particles
    public GameObject speedParticles; // speed particles
    public GameObject doubleMoneyParticles; // double money particles

    void Start()
    {
        doublePointsUI.SetActive(false); // sets double points UI to false
        invincibleUI.SetActive(false); // sets invincibility UI to false
    }

    void Update()
    {
        // check if player is killed and if so, stop spawning powerups
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            // check if double points is active
            if(isDoublePointsActive)
            {
                // if so, start the timer
                doublePointsTimer += Time.deltaTime;
                // if the timer is up, deactivate double points
                if(doublePointsTimer >= doublePointsTime)
                {
                    isDoublePointsActive = false;
                    doublePointsTimer = 0f;
                    doublePointsUI.SetActive(false);
                }
            }
            // check if invincibility is active
            if(isInvincibleActive)
            {
                // if so, start the timer
                invincibleTimer += Time.deltaTime;
                // if the timer is up, deactivate invincibility
                if(invincibleTimer >= invincibleTime)
                {
                    isInvincibleActive = false;
                    invincibleTimer = 0f;
                    invincibleUI.SetActive(false);
                }
            }
            // check if speed is active
            if(isSpeedActive)
            {
                // if so, start the timer
                speedTimer += Time.deltaTime;
                // if the timer is up, deactivate speed
                if(speedTimer >= speedTime)
                {
                    isSpeedActive = false;
                    speedTimer = 0f;
                }
            }

            // check if double money is active
            if(isDoubleMoneyActive)
            {
                // if so, start the timer
                doubleMoneyTimer += Time.deltaTime;
                // if the timer is up, deactivate double money
                if(doubleMoneyTimer >= doubleMoneyTime)
                {
                    isDoubleMoneyActive = false;
                    doubleMoneyTimer = 0f;
                    doubleMoneyUI.SetActive(false);
                }
            }
        }
    }

    // function to spawn powerups
    public void spawnPowerups(Vector3 position) 
    {
        // check if player is killed and if so, stop spawning powerups
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            // generate a random number between 0 and 100
            float randomNumber = Random.Range(0f, 100f);
            // if the random number is less than the chance to spawn a powerup
            if(randomNumber <= chanceToSpawn)
            {
                // generate a random number between 0 and the length of the powerup array
                int randomPowerup = Random.Range(0, powerups.Length);
                // spawn the powerup
                Instantiate(powerups[randomPowerup], position, Quaternion.identity);

                //set the powerup to active
                if(randomPowerup == 0)
                {
                    isDoublePointsActive = true;
                    doublePointsUI.SetActive(true);
                    doublePointsSound.GetComponent<AudioSource>().Play();
                    doublePointsParticles.SetActive(true);
                }
                else if(randomPowerup == 1)
                {
                    isInvincibleActive = true;
                    invincibleUI.SetActive(true);
                    invincibleSound.GetComponent<AudioSource>().Play();
                    invincibleParticles.SetActive(true);
                }
                else if(randomPowerup == 2)
                {
                    isSpeedActive = true;
                    speedUI.SetActive(true);
                    speedSound.GetComponent<AudioSource>().Play();
                    speedParticles.SetActive(true);
                }
                else if(randomPowerup == 3)
                {
                    isDoubleMoneyActive = true;
                    doubleMoneyUI.SetActive(true);
                    doubleMoneySound.GetComponent<AudioSource>().Play();
                    doubleMoneyParticles.SetActive(true);
                }
            }
        }
    }


*/
}
