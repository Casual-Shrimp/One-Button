using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    const float Speed = 0.1f;
    public float mouseX;
    public float mouseY;
    public CharacterController controller;
    
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = new Vector3(0, 0, 0);
    }

  
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Vector3 move = transform.right * mouseX + transform.up * mouseY;

        transform.Translate(move * Speed);

    }


}
