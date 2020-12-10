using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 100;
    public float destroyTime = 0.1f;

    public int GetDamage()
    {
        return damage;
    }
}
