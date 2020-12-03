using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenBattle : MonoBehaviour
{
    [SerializeField] GameObject powerUpScreen;
    public int enemies;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        powerUpScreen.SetActive(false);
    }

    public void OpenPowerupScreen()
    {      
        player.moveSpeed = 0;
        powerUpScreen.SetActive(true);
    }

    public void ClosePowerupScreen()
    {
        player.moveSpeed = player.startMoveSpeed;
        powerUpScreen.SetActive(false);
    }
}
