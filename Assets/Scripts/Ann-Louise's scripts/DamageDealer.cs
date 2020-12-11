using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage = 100;
    public float destroyTime = 0.1f;
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        damage += player.attackDamage;
    }
    public float GetDamage()
    {
        return damage;
    }
}
