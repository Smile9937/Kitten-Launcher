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

        //Change text
        UnityEngine.UI.Text roomEffectTextField = gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
        roomEffectTextField.text = card.roomText;
        
        UnityEngine.UI.Text activatedEffectTextField = gameObject.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>();
        activatedEffectTextField.text = card.activatedText;
        
        //Change image
        UnityEngine.UI.Image  currentSprite = gameObject.transform.GetChild(3).GetComponent<UnityEngine.UI.Image>();
        currentSprite.sprite = card.cardSprite;
    }

    public void GivePlayerCard()
    {
        player.cards.Add(card);
        betweenBattle.ClosePowerupScreen();
        player.GetClosestRoom().OpenDoors();
        player.GetClosestRoom().aquiredCard = true;
    }

    public void SelectCard()
    {

    }
}
