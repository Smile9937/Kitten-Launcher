using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPrefab : MonoBehaviour
{
    [SerializeField] Cards card;

    PlayerController player;
    BetweenBattle betweenBattle;
    GameSession gameSession;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
        gameSession = GameSession.Instance;
        
        //Change image
        UnityEngine.UI.Image currentSprite = gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        currentSprite.sprite = card.cardSprite;
    }

    public void GivePlayerCard()
    {
        gameSession.IncreasePlayerHealth(card.healthIncrease);
        gameSession.playerCards.Add(card);
        betweenBattle.ClosePowerupScreen();
        player.GetClosestRoom().OpenDoors();
        player.GetClosestRoom().aquiredCard = true;
        gameSession.OpenCanvas();
    }

    public void SelectCard()
    {
        gameSession.DecreasePlayerHealth(card.healthIncrease);
        player.attackBonus += card.attackDamage * player.GetClosestRoom().effectMultiplier;
        player.attackSpeedBonus += card.attackSpeed * player.GetClosestRoom().effectMultiplier;
        player.speedBonus += card.moveSpeed * player.GetClosestRoom().effectMultiplier;
        SummonObjects();
        gameSession.playerCards.Remove(card);
        betweenBattle.CloseDiscardCard();
        gameSession.OpenCanvas();
    }

    private void SummonObjects()
    {
        Vector3 roomPos = player.GetClosestRoom().transform.position;

        float summons = Mathf.Round(card.objectsToSummon * player.GetClosestRoom().effectMultiplier);

        for(int i = 0; i < summons; i++)
        {
            float randomPosX = UnityEngine.Random.Range(0, 13) * RandomSign();
            float randomPosY = UnityEngine.Random.Range(0, 8) * RandomSign();

            Instantiate(card.summon, new Vector2(roomPos.x + randomPosX, roomPos.y + randomPosY), transform.rotation);
        }
    }

    private int RandomSign()
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            return -1;
        }
        else { return 1; }
    }
}
