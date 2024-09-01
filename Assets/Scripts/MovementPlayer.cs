using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementPlayer : MonoBehaviour
{
    private float speed;
    public float inputX;
    public float inputY;
    private Rigidbody2D rb;
    public Flashlight flashlight;
    
    
    void Start()
    {
        flashlight = GameObject.Find("Flashlight").GetComponent<Flashlight>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

  
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

       // Vector3 move = transform.right * inputX + transform.up * inputY;
        
       // transform.Translate(move * speed * Time.deltaTime);

        
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3.5f;
        }
        else
        {
            speed = 2f;
        }
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX , inputY ) * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            flashlight.batteryCount += 1;
            Destroy(other.gameObject);
        }
    }
}
