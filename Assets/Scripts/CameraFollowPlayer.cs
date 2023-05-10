using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that allows the camera to follow the 2d player object as it moves around the scene with lerping
public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector3 roomPosition;

    void Start(){
        //set the room position to the starting room
        roomPosition = GameObject.FindGameObjectWithTag("Room").transform.position;
    }

    void FixedUpdate()
    {
        //check if the player is not null
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            //make the camera follow the player without changing the x axis

            // set minY to roomPosition.y - 8
            minY = roomPosition.y - 8;

            // set maxY to roomPosition.y + 8
            maxY = roomPosition.y + 8;

            Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);

            //clamp the camera so it doesn't go out of bounds
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

            //smooth the camera movement
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;



        }
    }

    //function called UpdateRoomPosition that takes in a vector3 of a room and sets the roomPosition to the room
    public void UpdateRoomPosition(Vector3 room){
        roomPosition = room;
    }
}
