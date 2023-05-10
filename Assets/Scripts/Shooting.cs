using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    //script that spawns the bullet prefab and gives it a velocity in the direction the player is facing when the player presses the left mouse button
    // Start is called before the first frame update

    public float bulletSpeed = 20f;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject shootEffect;

    // grabs fire rate from the UpgradeSystem script and sets it to the fireRate variable
    public float fireRate = UpgradeSystem.fireSpeed;
    private float nextFire = 0.0f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses the left mouse button and the current time is greater than the nextFire time, then the player can shoot
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            
            //check if the player is dashing
                Shoot();

            
        }

        //shoot if Fire1 is held down 

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //scales the bullet by the multiplier bulletScale values variable from the UpgradeSystem script
        bullet.transform.localScale = new Vector3(UpgradeSystem.bulletScale, UpgradeSystem.bulletScale, 1);

        //Shoot the bullet towards the mouse cursor
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Shoot the bullet towards mousePos
        Vector2 shootDir = mousePos - (Vector2)firePoint.position;

        // Normalize the shootDir vector to have a magnitude of 1
        shootDir.Normalize();

        // Set the velocity of the bullet to shootDir * bulletSpeed

        bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;

        //Ignore collision between the bullet and the player
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        //Spawn shoot effect at the firepoint
        GameObject effect = Instantiate(shootEffect, firePoint.position, Quaternion.identity);
        

        //get the particle system component from the shoot effect 
        ParticleSystemRenderer effectChild = effect.GetComponentInChildren<ParticleSystemRenderer>();
        effectChild.pivot = new Vector2(1, 1f);


        //set effect position to the firepoint position
        effect.transform.position = firePoint.position;

        //rotate the effect to face the mouse cursor
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 180f;
        effect.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        effect.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        //Destroy the shoot effect after 0.02 seconds
        Destroy(effect, 0.05f);

        //make effect disabled
        effect.SetActive(false);





    }
}
