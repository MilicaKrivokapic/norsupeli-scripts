using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed = 2.0f;
    public int maxHealth = 1;
    public float horizontal = 0.0f;
    public float vertical = 1.0f;
    public ParticleSystem heartParticle;

    public bool goingUp = true;
    public float movingTime = 2.0f;
    float directionTimer;
    float deathTimer = 1.0f;
    bool death = false;
    Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        directionTimer = movingTime;
        animator = GetComponent<Animator>();
        heartParticle.enableEmission = false;
    }

    void FixedUpdate()
    {
        if(!death) {
            directionTimer -= Time.deltaTime;
            if (directionTimer < 0) {
                goingUp = !goingUp;
                directionTimer = movingTime;
            }
            if (goingUp)
            {
                vertical = 1.0f;
                animator.SetFloat("moveY", vertical);
            }
            else
            {
                vertical = -1.0f;
                animator.SetFloat("moveY", vertical);
            }
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        } else {
            deathTimer -= Time.deltaTime;
            if(deathTimer < 0) {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void NonExist()
    {
        death = true; 
        heartParticle.enableEmission = true;  
    }

}
