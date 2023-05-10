using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// this script will be used to upgrade the reload speed of the player's gun when the player purchases the upgrade
// It increases the reload speed by 0.1 seconds in UpgradeSystem.cs
public class ReloadSpeedUpgrade : MonoBehaviour
{
    public int cost = 1; // initiates a cost integer variable
    public int level = 0; // initiates a level integer variable


    public void ReloadSpeedUpgradeButton()
    {
        if (MoneyHandler.moneyVal >= cost)
        {
            MoneyHandler.moneyVal -= cost;
            UpgradeSystem.fireSpeed -= 0.1f;
            cost += (cost * 2);
            level += 1;

            //change the text that is a child of the button called CostLabel
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Cost: " + cost + "\nLevel " + level;
        }
    }

    // Change the color of the actual normal color button to red if the player does not have enough money to purchase the upgrade
    void Update()
    {
        if (MoneyHandler.moneyVal < cost)
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = Color.black;
        }
    }
}
