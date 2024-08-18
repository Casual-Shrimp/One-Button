using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] float health;
    // Start is called before the first frame update
    void Start()
    {
      health = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        OnDeath();        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            health--;
        }
    }


    void OnDeath()
    {
        if(health <= 0)
        {
            
            Destroy(this.gameObject);
        }
    }



}
