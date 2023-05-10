using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the upgrade system. It will be used to upgrade the player's health, speed, and damage. 
// The player purchases upgrades with money collected from money pickups.
// This purchase is done through the UI buttons in the upgrade menu.
// The upgrade menu is accessed through the pause menu.

public class UpgradeSystem : MonoBehaviour
{
    public static float fireSpeed = 1.0f; // initiates a fire speed integer variable set to 1

    public static float bulletScale = 0.12f; // initiates a bullet scale integer variable set to 1


    public void updateFireSpeed(float increase) // function that updates the fire speed
    {
        fireSpeed += increase; // adds the increase value to the fire speed
    }

    public void updateBulletScale(float increase) // function that updates the bullet scale
    {
        bulletScale += increase; // adds the increase value to the bullet scale
    }
    
}
