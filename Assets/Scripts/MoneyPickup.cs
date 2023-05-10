using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{

    // when the player collides with the money pickup, the money pickup is destroyed and the money is increased by 1
    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            MoneyHandler.moneyVal += 1;
            Destroy(gameObject);
        }
    }
}
