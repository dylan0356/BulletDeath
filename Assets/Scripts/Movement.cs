using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//2d movement script for player character using rigidbody2d
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    Vector2 mousePos;
    public Rigidbody2D rb;

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
        //HandleMouseFollowing();

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical")));
    }

    // makes the player face the mouse cursor
    void HandleMouseFollowing()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; // subtract 90 degrees to account for the sprite's default rotation
        rb.rotation = angle;
    }

    void HandlePlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal * speed, vertical * speed, 0f);

        transform.position += movement * Time.deltaTime;
    }
}
