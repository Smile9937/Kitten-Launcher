using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
    public class Weapon : ScriptableObject
    {
        public Sprite currentWeaponSpr;
        public DamageDealer bulletPrefab;
        public float fireRate = 1;
        public int damage = 20;

        public void Shoot()
        {
            DamageDealer bullet = Instantiate(bulletPrefab, GameObject.Find("Firepoint").transform.position, Quaternion.identity);
            bullet.damage = damage;
        }
    }

