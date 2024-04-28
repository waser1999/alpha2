using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float walkSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Walk(Input.GetAxis("Horizontal"));
        }
    }

    private void Walk(float horizontal)
    {
        float xVelocity = horizontal * walkSpeed * Time.deltaTime;
        rb.velocity = new Vector2 (xVelocity, rb.velocity.y);

        transform.localScale = new Vector3(Math.Sign(xVelocity) * -1, transform.localScale.y, transform.localScale.z);
    }
}
