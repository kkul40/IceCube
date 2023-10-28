using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public Vector2 moveDelta = new Vector2();

    public Rigidbody2D rb2;
    
    private void FixedUpdate()
    {
        moveDelta.x = Input.GetAxis("Horizontal");
        moveDelta.y = Input.GetAxis("Vertical");
        
        
        
        rb2.AddForce(moveDelta, ForceMode2D.Impulse);
    }
}
