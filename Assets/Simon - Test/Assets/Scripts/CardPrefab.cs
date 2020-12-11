using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPrefab : MonoBehaviour
{
    [SerializeField] Cards card;

    PlayerController player;
    BetweenBattle betweenBattle;
    RoomManager roomManager;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
        roomManager = FindObjectOfType<RoomManager>();
        
        //Change image
        UnityEngine.UI.Image  currentSprite = gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        currentSprite.sprite = card.cardSprite;
    }

    public void GivePlayerCard()
    {
        Debug.Log("Give Prefab Button Working");
        player.cards.Add(card);
        betweenBattle.ClosePowerupScreen();
        player.GetClosestRoom().OpenDoors();
        player.GetClosestRoom().aquiredCard = true;
    }

    public void SelectCard()
    {
        Debug.Log("Select Prefab Button Working");
        player.attackBonus += card.attackDamage * player.GetClosestRoom().effectMultiplier;
        player.attackSpeedBonus += card.attackSpeed * player.GetClosestRoom().effectMultiplier;
        player.speedBonus += card.moveSpeed * player.GetClosestRoom().effectMultiplier;
        player.cards.Remove(card);
        betweenBattle.CloseDiscardCard();
    }
}
