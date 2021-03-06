﻿
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 500f;
    bool isJumping = false;
	
	// fixedupdate is better for physics
	void FixedUpdate ()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);	

        if (Input.GetKey("d")) //right
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))//left
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }


        if (Input.GetKey("space"))//jump
        {
            Debug.Log("Jump!");
            Jump();
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
	}


    void Jump()
    {
        if (isJumping == false)
        {
            isJumping = true;
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            Invoke("Land", .3f);
        }  
    }

    void Land()
    {
        rb.AddForce(0, -jumpForce*2, 0, ForceMode.VelocityChange);
        isJumping = false;
    }
}
