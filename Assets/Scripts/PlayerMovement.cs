using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Walk")]
    public float walkSpeed;
    public float accelerateSpeed;
    public float decelerateSpeed;
    public float turnSpeed;

    [Header("Jump")]
    public float jumpSpeed;
    public float jumpBuffer;
    public float dropGravity;

    private float finalVelocity;
    private float jumpBufferCounter;
    private bool hasJumpBuffer = false;
    private float defaultGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        defaultGravity = rb.gravityScale;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }    
    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private bool OnGround()
    {
        LayerMask ground = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, ground);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void Jump()
    {
        bool jumpPressed = Input.GetAxisRaw("Jump") != 0;

        if (jumpPressed && !hasJumpBuffer && OnGround())
        {
            hasJumpBuffer = true;
            jumpBufferCounter = 0f;
        }

        if (hasJumpBuffer)
        {
            if(jumpPressed){
                rb.velocity += Vector2.up * jumpSpeed;
                jumpBufferCounter += Time.deltaTime;
            }
            

            if (jumpBufferCounter > jumpBuffer || !jumpPressed)
            {
                hasJumpBuffer = false;
            }
        }

        if (rb.velocity.y < 0f && this.OnGround() == false)
        {
            rb.gravityScale = dropGravity;
        }
        else
        {
            rb.gravityScale = defaultGravity;
        }
    }

    private void Walk()
    {
        float xVelocity = Time.deltaTime;
        float moveVelocity = rb.velocity.x;
        int direction = Math.Sign(Input.GetAxisRaw("Horizontal"));

        if (direction != 0)
        {
            transform.localScale = new Vector3(direction * -1, transform.localScale.y, transform.localScale.z);

            if (direction == Math.Sign(rb.velocity.x))
            {
                xVelocity *= accelerateSpeed;
            }
            else
            {
                xVelocity *= turnSpeed;
            }

            finalVelocity = walkSpeed * direction;
        }
        else
        {
            xVelocity *= decelerateSpeed;
            finalVelocity = 0f;
        }

        moveVelocity = Mathf.MoveTowards(moveVelocity, finalVelocity, xVelocity);
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);


        if (rb.velocity.x != 0 && OnGround())
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }
}
