using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RepairStation : MonoBehaviour
{
    
    public TextMeshProUGUI usePrompt;
    public GameObject Enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        usePrompt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            usePrompt.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(Enemy, transform.position, Quaternion.identity);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        usePrompt.enabled = false;
    }
}
