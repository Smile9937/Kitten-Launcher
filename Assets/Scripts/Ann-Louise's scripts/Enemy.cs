﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //REMEMBER to add a collider to enemies and make the projectile a trigger
    public float startHealth = 100f;
    [SerializeField] GameObject enemyReward;
    public float health;
    PlayerController player;
    BetweenBattle betweenBattle;
    SpriteRenderer spriteRenderer;
    bool preventMultiDeath = false;
    void Start()
    {
        health = startHealth;
        player = FindObjectOfType<PlayerController>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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

        //health -= damageDealer.GetDamage();
        TakeDamage(damageDealer.GetDamage());

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        spriteRenderer.color = Color.blue;
        Invoke("ChangeBackColor", 0.1f);

        if (health <= 0f && !preventMultiDeath)
        {
            preventMultiDeath = true;
            player.GetClosestRoom().enemies--;
            if (player.GetClosestRoom().enemies <= 0 && player.GetClosestRoom().spawnerInRoom == false)
            {
                betweenBattle.OpenPowerupScreen();
            }
            if (enemyReward != null) { Instantiate(enemyReward, transform.position, transform.rotation); }
            Destroy(gameObject);
        }
    }

    void ChangeBackColor()
    {
        spriteRenderer.color = Color.white;
    }
}
