﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float nextTimeOfFire = 0;
    public Weapon currentWeapon;

    [SerializeField] GameObject damageParticles;

    [Header("Player Stats")]
    public float startingMoveSpeed = 10f;

    [Header("Do not edit unless debugging or testing")]
    public List<Cards> cards;

    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float defence = 0;

    public float speedBonus = 1;
    public float attackBonus = 1;
    public float attackSpeedBonus = 1;

    public float passiveAttackSpeedBonus;
    public float passiveAttackBonus;

     
    float startMoveSpeedBonus = 0;
    float startingAttackBonus = 0;
    float startingAttackSpeed = 0;

    public List<Transform> rooms;

    bool canBeHit = true;
    public bool canShoot = true;

    bool isPaused = false;

    GameObject gun;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    SpriteRenderer spriteRenderer;
    SceneTransition sceneTransition;
    GameSession gameSession;
    SoundLibrary soundLibrary;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sceneTransition = FindObjectOfType<SceneTransition>();
        gameSession = GameSession.Instance;
        gun = GameObject.Find("Gun_Placeholder");
        soundLibrary = SoundLibrary.Instance;
        gun.GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;
    }
    
    void Update()
    {
        if(!isPaused)
        {
            myAnimator.SetBool("Idle", false);
            Move();
            HorizontalAnimation();
            VerticalAnimation();
            ChangeStats();
            Shoot();
            FlipSpriteHorizontal();
            if (!currentWeapon.isCatLauncher)
            {
                gun.GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;
            }
        } else
        {
            myRigidbody.velocity = new Vector2(0, 0);
            myAnimator.SetBool("Idle", true);
            myAnimator.SetBool("Side", false);
            myAnimator.SetBool("Back", false);
            myAnimator.SetBool("Front", false);  
        }

    }
    private void ChangeStats()
    {
        if (cards != gameSession.playerCards)
        {
            cards = gameSession.playerCards;
        }
        if (currentWeapon != gameSession.currentPlayerWeapon)
        {
            currentWeapon = gameSession.currentPlayerWeapon;
        }

        GainPassiveStats();

        moveSpeed = startingMoveSpeed + speedBonus;
        attackDamage = startingAttackBonus + attackBonus + passiveAttackBonus;
        attackSpeed = startingAttackSpeed + attackSpeedBonus + passiveAttackSpeedBonus;
    }
    private void GainPassiveStats()
    {
        if(cards == null) { return; }
        if(cards.Count + 1 == 0)
        {
            passiveAttackBonus = cards[0].passiveAttackDamage;
            passiveAttackSpeedBonus = cards[0].passiveAttackSpeed;
        }
        else
        {
            float tempAttackBonus = 0;
            float tempAttackSpeedBonus = 0;

            for(int i = 0; i < cards.Count; i++)
            {
                if(cards[i] != null)
                {
                    tempAttackBonus += cards[i].passiveAttackDamage;
                    tempAttackSpeedBonus += cards[i].passiveAttackSpeed;
                }
            }
            passiveAttackBonus = tempAttackBonus;
            passiveAttackSpeedBonus = tempAttackSpeedBonus;
        }
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

        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        bool hasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

        if(hasHorizontalSpeed && hasVerticalSpeed)
        {
            moveSpeed /= 1.2f;
        }

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
        if (damageParticles != null) { Instantiate(damageParticles, transform.position, transform.rotation); }
        spriteRenderer.color = Color.blue;
        Invoke("ChangeBackColor", 0.1f);
        gameSession.DecreasePlayerHealth(damageDealer.GetDamage());
        soundLibrary.PlayerHitSFX();
        if (gameSession.GetPlayerHealth() <= 0)
        {
            sceneTransition.Lose();
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
        if (canShoot)
        {
            if(Time.time >= nextTimeOfFire) { gun.GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr; }
            if (Input.GetMouseButton(0))
            {
                if (Time.time >= nextTimeOfFire)
                {
                    if(currentWeapon.isCatLauncher) { gun.GetComponent<SpriteRenderer>().sprite = currentWeapon.secondarySprite; }
                    currentWeapon.Shoot();
                    soundLibrary.PlayWeaponSound(currentWeapon.weaponSoundIndex);
                    nextTimeOfFire = Time.time + 1 / (currentWeapon.fireRate + attackSpeed);
                }
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

    public void ResetStats()
    {
        speedBonus = startMoveSpeedBonus;
        attackBonus = startingAttackBonus;
        attackSpeedBonus = startingAttackSpeed;

        passiveAttackBonus = startingAttackBonus;
        passiveAttackSpeedBonus = startingAttackBonus;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }

}







