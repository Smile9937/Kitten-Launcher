using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public List<Cards> playerCards;
    float playerHealth;
    PlayerController player;

    public static GameSession Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerHealth = player.health;
    }

    public float GetPlayerHealth()
    {
        return playerHealth;
    }

    public void IncreasePlayerHealth(float healthIncrease)
    {
        playerHealth += healthIncrease;
    }

    public void DecreasePlayerHealth(float healthDecrease)
    {
        playerHealth -= healthDecrease;
    }

    public List<Cards> GetPlayerCards()
    {
        return playerCards;
    }

    public void IncreasePlayerCards(Cards card)
    {
        playerCards.Add(card);
    }

    public void DecreasePlayerCards(Cards card)
    {
        playerCards.Remove(card);
    }
}
