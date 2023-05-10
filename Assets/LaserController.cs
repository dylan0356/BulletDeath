using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if player collides with laser, call KillPlayer() from Player script
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Player>().KillPlayer();
        }
    }
}
