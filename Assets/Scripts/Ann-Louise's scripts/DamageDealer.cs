using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] bool isCatLauncher;
    [SerializeField] bool isPlayerBullet;
    public float damage = 100;
    public float destroyTime = 0.1f;
    PlayerController player;
    Shot shot;

    private void Start()
    {
        shot = GetComponent<Shot>();
        player = FindObjectOfType<PlayerController>();
        if (isPlayerBullet) { damage += player.attackDamage; }
        if(isCatLauncher) {shot.extraCatDamage = damage / 10; }
    }
    public float GetDamage()
    {
        if(!isCatLauncher)
        {
            return damage;
        } else
        {
            return 0;
        }

    }
}
