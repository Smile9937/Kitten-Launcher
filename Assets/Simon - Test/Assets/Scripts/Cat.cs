﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float damageSpeed;
    [SerializeField] float timeOnEnemy;
    void Start()
    {
        Invoke("DestroyGameObject", timeOnEnemy);
        StartCoroutine(DamageEnemy());
    }

    IEnumerator DamageEnemy()
    {
        //Damage Enemy
        GameObject enemy = transform.parent.gameObject;
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.TakeDamage(damage);
        yield return new WaitForSeconds(damageSpeed);
        StartCoroutine(DamageEnemy());

    }

    private void Update()
    {
        GameObject enemy = transform.parent.gameObject;
        SpriteRenderer enemySpriterenderer = enemy.GetComponent<SpriteRenderer>();
        if(enemySpriterenderer == null)
        {   
            GameObject enemyChild = enemy.gameObject.transform.GetChild(0).gameObject;
            transform.position = enemyChild.transform.position;
        } else
        {
            transform.position = enemy.transform.position;
        }

       
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}