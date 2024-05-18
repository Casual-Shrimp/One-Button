using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Destroy(this.gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLISION AAAA");
        Destroy(collision.gameObject);
    }


}
