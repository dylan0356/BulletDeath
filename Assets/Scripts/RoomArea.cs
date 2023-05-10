using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomArea : MonoBehaviour
{
    public bool isPlayerInRoom = false;


    public int currentEnemies = -1;
    public GameObject currentObject;

    public GameObject door;



    // Start is called before the first frame update
    void Start()
    {

  
        //wait 1 second then call GetDoor()
        Invoke("GetDoor", 0.01f);


    }

        // Update is called once per frame
    void Update()
    {

        //update current enemies
        currentEnemies = transform.parent.gameObject.GetComponent<EnemySpawningRoom>().enemiesLeft;

        if (currentEnemies == 0)
            {
                //Open the room
                OpenRoom();
            }
                
    }

    private void GetDoor()
    {
        currentEnemies = transform.parent.gameObject.GetComponent<EnemySpawningRoom>().enemiesLeft;
        currentObject = transform.parent.gameObject;

        //get third child of currentObject and set it to door
        door = currentObject.transform.GetChild(2).gameObject;
        
        door = door.transform.GetChild(2).gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
        {

            Debug.Log("Player is in room");
            isPlayerInRoom = true;
            CloseRoom();

            //set currentRoom to the room the player is in
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left room");
            isPlayerInRoom = false;
        }
    }

    //Close the room
    void CloseRoom()
    {
        //Find object with Door tag and disable it

                //Disable the door
                door.SetActive(true);
            
        

    }

    //Open the room
    void OpenRoom()
    {
                //check if door is null
                if (door != null)
                {
                    //Enable the door
                    door.SetActive(false);
                }
                
        

    }
}
