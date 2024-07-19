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

        if(health <= 0)
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
        }
       if(other.gameObject.CompareTag("Explosion"))
        {
            health--;
        }
    }




}
