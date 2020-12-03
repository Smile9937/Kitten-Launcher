using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BetweenBattle betweenBattle;
    void Start()
    {
        betweenBattle.enemies++;
    }

    void Update()
    {
        
    }
}
