using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float nextTimeOfFire = 0;
    public Weapon currentWeapon;

    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 200;

    Rigidbody2D myRigidbody;
    
    Vector2 movement;
    Animator myAnimator;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleCharacterMovement();
        Shoot();
        FlipSpriteHorizontal();
    }

    private void FlipSpriteHorizontal()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed)
        {
            var xVelocity = Mathf.Sign(myRigidbody.velocity.x);
            var localScaleCheck = Mathf.Sign(transform.localScale.x);
            transform.localScale = new Vector2(xVelocity * transform.localScale.x * localScaleCheck, transform.localScale.y);
        }
    }

    private void HandleCharacterMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        Vector2 playerVelocity = new Vector2(horizontalMove * moveSpeed, verticalMove * moveSpeed);
        myRigidbody.velocity = playerVelocity;

        Debug.Log(playerVelocity);

        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Side", hasHorizontalSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            ProcessHit(damageDealer);
        }
        
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        Debug.Log("wtf");
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Shoot()
       {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextTimeOfFire)
            {
                currentWeapon.Shoot();
                nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
            }

        }
       }

}







