using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float walkSpeed;
    public float jumpForce;
    public float jumpBuffer;

    private float jumpBufferCounter;
    private bool hasJumpBuffer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void Jump()
    {
        bool jumpPressed = Input.GetAxisRaw("Jump") != 0;
        bool onGround = true;

        if(jumpPressed && !hasJumpBuffer && onGround)
        {
            hasJumpBuffer = true;
            jumpBufferCounter = 0f;
        }
        
        if(hasJumpBuffer)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpBufferCounter += Time.deltaTime;
            
            if(jumpBufferCounter > jumpBuffer)
            {
                hasJumpBuffer = false;
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(Vector2.down * jumpForce * 2, ForceMode2D.Impulse);
            }
        }
    }

    private void Walk()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        float horizontal = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            float xVelocity = horizontal * walkSpeed * Time.deltaTime;
            rb.velocity = new Vector2(xVelocity, rb.velocity.y);

            transform.localScale = new Vector3(direction * -1, transform.localScale.y, transform.localScale.z);

            animator.SetBool("isWalk", true);
        }
        else if (rb.velocity.x == 0)
        {
            animator.SetBool("isWalk", false);
        }
    }
}
