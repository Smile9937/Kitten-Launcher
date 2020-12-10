using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float nextTimeOfFire = 0;
    public Weapon currentWeapon;

    [Header("Player")]
    public float moveSpeed = 10f;
    [SerializeField] int health = 200;

    public List<Cards> cards;

    public List<Transform> rooms;

    public float startMoveSpeed = 10f;

    public float speedBonus;

    bool canBeHit = true;

    GameObject gun;

    Rigidbody2D myRigidbody;

    Animator myAnimator;

    SpriteRenderer spriteRenderer;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gun = GameObject.Find("Gun_Placeholder");
    }
    
    void Update()
    {
        Move();
        HorizontalAnimation();
        VerticalAnimation();
        Shoot();
        FlipSpriteHorizontal();

        gun.GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;
    }

    private void FlipSpriteHorizontal()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed)
        {
            float xVelocity = Mathf.Sign(myRigidbody.velocity.x);
            float localScaleCheck = Mathf.Sign(transform.localScale.x);
            transform.localScale = new Vector2(xVelocity * transform.localScale.x * localScaleCheck, transform.localScale.y);
        }
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        Vector2 playerVelocity = new Vector2(horizontalMove * moveSpeed, verticalMove * moveSpeed);
        myRigidbody.velocity = playerVelocity;
    }

    void HorizontalAnimation()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Side", hasHorizontalSpeed);
    }

    void VerticalAnimation()
    {
        bool hasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

        float yVelocity = Mathf.Sign(myRigidbody.velocity.y);

        bool movingUp = yVelocity == 1 && hasVerticalSpeed;
        myAnimator.SetBool("Back", movingUp);

        bool movingDown = yVelocity == -1 && hasVerticalSpeed;
        myAnimator.SetBool("Front", movingDown);
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
        if (!canBeHit) { return; }
        canBeHit = false;
        spriteRenderer.color = Color.red;
        Invoke("ChangeBackColor", 0.1f);
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(MultiHitPrevention());
    }

    void ChangeBackColor()
    {
        spriteRenderer.color = Color.white;
    }

    IEnumerator MultiHitPrevention()
    {
        yield return new WaitForEndOfFrame();
        canBeHit = true;
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

    public RoomManager GetClosestRoom()
    {
        RoomManager closestRoom = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in rooms)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestRoom = potentialTarget.GetComponent<RoomManager>();
            }
        }
        return closestRoom;
    }

}







