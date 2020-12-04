using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClearTest : MonoBehaviour
{
    BetweenBattle betweenBattle;
    void Start()
    {
        betweenBattle = FindObjectOfType<BetweenBattle>();
        betweenBattle.enemies++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            betweenBattle.enemies--;
            if(betweenBattle.enemies == 0)
            {
                betweenBattle.OpenPowerupScreen();
            }
            Destroy(gameObject);
        }
    }
}
