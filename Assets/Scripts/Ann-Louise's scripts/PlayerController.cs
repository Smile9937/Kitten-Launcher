using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float nextTimeOfFire = 0;
    public Weapon currentWeapon;

    [Header("Player Stats")]
    public float startingMoveSpeed = 10f;

    public float health = 200;

    [Header("Do not edit unless debugging or testing")]
    public List<Cards> cards;

    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;

    public float speedBonus;
    public float attackBonus;
    public float attackSpeedBonus;

    public float passiveAttackSpeedBonus;
    public float passiveAttackBonus;

     
    float startMoveSpeedBonus = 0;
    float startingAttackBonus = 0;
    float startingAttackSpeed = 0;

    public List<Transform> rooms;

    bool canBeHit = true;

    GameObject gun;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    SpriteRenderer spriteRenderer;
    SceneTransition sceneTransition;
    GameSession gameSession;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sceneTransition = FindObjectOfType<SceneTransition>();
        gameSession = GameSession.Instance;
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
        ChangeStats();
    }
    private void ChangeStats()
    {
        if (cards != gameSession.playerCards)
        {
            cards = gameSession.playerCards;
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
                tempAttackBonus += cards[i].passiveAttackDamage;
                tempAttackSpeedBonus += cards[i].passiveAttackSpeed;
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
        spriteRenderer.color = Color.blue;
        Invoke("ChangeBackColor", 0.1f);
        gameSession.DecreasePlayerHealth(damageDealer.GetDamage());
        gameSession.ChangeHealthText();
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
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextTimeOfFire)
            {
                currentWeapon.Shoot();
                nextTimeOfFire = Time.time + 1 / (currentWeapon.fireRate + attackSpeed);
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

}







