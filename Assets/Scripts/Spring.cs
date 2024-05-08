using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float jumpForce;
    
    private void OnCollisionEnter2D(Collision2D other) {
        Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();

        if(other.gameObject.CompareTag("Player")){
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
    }
}
