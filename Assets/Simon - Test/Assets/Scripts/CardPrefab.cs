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
        gameSession.playerCards.Add(card);
        betweenBattle.ClosePowerupScreen();
        player.GetClosestRoom().OpenDoors();
        player.GetClosestRoom().aquiredCard = true;
        gameSession.OpenCanvas();
    }

    public void SelectCard()
    {
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

        int randomPos = UnityEngine.Random.Range(0, 5);
        Vector3 roomPos = player.GetClosestRoom().transform.position;

        for(int i = 0; i < card.objectsToSummon; i++)
        {
            Instantiate(card.summon, new Vector2(roomPos.x + randomPos, roomPos.y + randomPos), transform.rotation);
        }
    }
}
