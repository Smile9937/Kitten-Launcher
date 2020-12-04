using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    PlayerController player;

    public int damage = 100;
    
    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

/*    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (CompareTag("PlayerBullet"))
        {
            damage = player.currentWeapon.damage;
        }
    } */

}
