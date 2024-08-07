using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCircle : MonoBehaviour
{
    public bool canSee;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canSee = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canSee = false;
           
        }
    }
}
