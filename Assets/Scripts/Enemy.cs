using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private GameObject player;
    private bool hasLineOfSight = false;
    public SightCircle SightCircle;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        target = GameObject.Find("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
                


    }

    // Update is called once per frame
    void Update()
    {
        if (SightCircle.canSee)
        {
            InSight();    
        }
        if (hasLineOfSight == false || !player)
        {
            rb.velocity = rb.velocity / 1.0099f;
            rb.freezeRotation = true;
        }
    }

    private void FixedUpdate()
    {
        if (player)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
            if (ray.collider)
            {
                hasLineOfSight = ray.collider.CompareTag("Player");
                if (hasLineOfSight)
                {
                    rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                }
                else
                {
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                }
            }
        }
    }

    private void InSight()
    {
        if (player != null)
        {
            if (hasLineOfSight)
            {

                Vector3 direction = (target.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
                moveDirection = direction;
              
            }
        }
        
    }


}
