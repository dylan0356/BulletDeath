using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    //RoomArea object
    public GameObject roomArea;

    
    //When the player collides with collider with the tag "Room" snap the camera to the centre of the room without changing the z axis. But allows the camera to move on the Y axis
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Room")){
            
            Camera.main.transform.position = new Vector3(other.transform.position.x, Camera.main.transform.position.y , Camera.main.transform.position.z);

            //call the UpdateRoomPosition function from the CameraFollowPlayer script and pass in the other.transform.position
            Camera.main.GetComponent<CameraFollowPlayer>().UpdateRoomPosition(other.transform.position);
        }

    
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //Find all objects with the tag RoomArea and store it in the roomArea array
        GameObject[] roomAreas = GameObject.FindGameObjectsWithTag("RoomArea");
        
    }

    public void KillPlayer()    {

        //enable game over menu by finding the game over menu object and setting its child to active
        GameObject gameOverMenu = GameObject.Find("GameOverMenu");
        gameOverMenu.transform.GetChild(0).gameObject.SetActive(true);

        Destroy(gameObject);
    }



}
