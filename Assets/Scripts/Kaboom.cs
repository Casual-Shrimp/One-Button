using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaboom : MonoBehaviour
{

    public GameObject explosion;
    [SerializeField] float health = 2;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            health--;
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        Destroy(collision.gameObject);
    }




}
