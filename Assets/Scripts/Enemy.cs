using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody2D _rb;
    Transform _target;
    Vector2 _moveDirection;
    private float health = 40f;
    private GameObject _player;
    private bool _hasLineOfSight;
    public SightCircle sightCircle;
    public Light2D _glare;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
        _target = GameObject.Find("Player").transform;
        _player = GameObject.FindGameObjectWithTag("Player");
        _glare.intensity = 1f;
    }

    // Update is called once per frame
    void Update()
    { 
        InSight();
        LostSight();
        EnemyHealth();
    }

    private void FixedUpdate()
    {
        if (_player)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, _player.transform.position - transform.position);
            if (ray.collider)
            {
                _hasLineOfSight = ray.collider.CompareTag("Player");
                if (_hasLineOfSight)
                {
                   
                    Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.green);
                }
                else
                {
                    Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.red);
                }
            }
        }
    }

    private void InSight()
    {
        if (_player)
        {
            if (_hasLineOfSight && sightCircle.canSee)
            {
                _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y) * speed;
                Vector3 direction = (_target.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _rb.rotation = angle;
                _moveDirection = direction;
              
            }
        }
        
    }

    private void LostSight()
    {
        if (_hasLineOfSight == false || !_player || sightCircle.canSee == false)
        {
            _rb.velocity  /= 1.0999f;
            _rb.freezeRotation = true;
        }
    }

    private void EnemyHealth()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LightBeam"))
        {
            health -=0.2f;
            speed = 0.4f;
            _glare.enabled = true;
            _glare.intensity *= 1.1f;
            Debug.Log(_glare.intensity);
            
        }
        else
        {
            speed = 2.5f;
            _glare.enabled = false;
        }
    }
}
