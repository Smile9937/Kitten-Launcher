using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClearTest : MonoBehaviour
{
    Player player;
    BetweenBattle betweenBattle;
    void Start()
    {
        player = FindObjectOfType<Player>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetClosestRoom().enemies--;
            if(player.GetClosestRoom().enemies == 0)
            {
                betweenBattle.OpenPowerupScreen();
            }
            Destroy(gameObject);
        }
    }
}
