using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    const float Speed = 0.1f;
    public float inputX;
    public float inputY;
    Rigidbody2D rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = new Vector3(0, 0, 0);
    }

  
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputX + transform.up * inputY;

        transform.Translate(move * Speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }


}
