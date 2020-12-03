﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //REMEMBER to add a collider to enemies and make the projectile a trigger

    [SerializeField] float health = 100f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
        ProcessHit();
    }

    private void ProcessHit()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

}