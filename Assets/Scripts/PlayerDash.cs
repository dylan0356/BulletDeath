using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that allows the player to dash in the direction they are facing when they press the space key
public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    private int direction;
    private Rigidbody2D rb;
    public bool isDashing;

    public float dashCooldown = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        if(direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(Input.GetKey(KeyCode.A))
                {
                    direction = 1;
                }
                else if(Input.GetKey(KeyCode.D))
                {
                    direction = 2;
                }
                else if(Input.GetKey(KeyCode.W))
                {
                    direction = 3;
                }
                else if(Input.GetKey(KeyCode.S))
                {
                    direction = 4;
                }
            }
        }
        else
        {
            //check dashCooldown

            

            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                isDashing = false;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    isDashing = true;
                }
                else if(direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    isDashing = true;
                }
                else if(direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                    isDashing = true;
                }
                else if(direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                    isDashing = true;
                }
            }
        }
    }
}
