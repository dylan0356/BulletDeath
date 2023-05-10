using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//handles the money UI and the money pickup system
public class MoneyHandler : MonoBehaviour
{
    public static int moneyVal = 0; // initiates a money integer variable set to 0
    public GameObject moneyUI; // string UI

    TextMeshProUGUI MoneyTextUI; // string UI


    void Start(){
        MoneyTextUI = moneyUI.GetComponent<TextMeshProUGUI>(); // gets the money UI component
    }

    void Update() {
        MoneyTextUI.text = "$: " + moneyVal; // updates the money UI
    }
}
