using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] private Vector2 moveDelta = new Vector2();
    [SerializeField] private Vector2 maxForce;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDelta.x = Input.GetAxis("Horizontal");
        moveDelta.y = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded())
        {
            rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (Math.Abs(rb2.velocity.x) < maxForce.x)
        {
            rb2.AddForce(moveDelta * moveForce, ForceMode2D.Impulse);
            // Debug.Log(rb2.velocity.y);
        }
        
        var velocity = rb2.velocity;
        velocity.x = Math.Clamp(velocity.x, -maxForce.x, maxForce.x);
        velocity.y = Math.Clamp(velocity.y, -maxForce.y, maxForce.y);

        rb2.velocity = velocity;
    }
    
    private bool IsGrounded()
    {
        return false;
    }
}
