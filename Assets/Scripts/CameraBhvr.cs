using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBhvr : MonoBehaviour
{
    public GameObject player;
    public float camFOV = -5;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + camFOV);
        }
        
    }
}
