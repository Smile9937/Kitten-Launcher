using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEdit : MonoBehaviour
{
    [SerializeField] Cards card;

    Player player;
    BetweenBattle betweenBattle;
    void Start()
    {
        player = FindObjectOfType<Player>();
        betweenBattle = FindObjectOfType<BetweenBattle>();

        //Change text
        UnityEngine.UI.Text roomEffectTextField = gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
        roomEffectTextField.text = card.roomText;
        
        UnityEngine.UI.Text activatedEffectTextField = gameObject.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>();
        activatedEffectTextField.text = card.roomText;
        
        //Change image
        UnityEngine.UI.Image  currentSprite = gameObject.transform.GetChild(3).GetComponent<UnityEngine.UI.Image>();
        currentSprite.sprite = card.cardSprite;
    }

    public void GivePlayerCard()
    {
        player.cards.Add(card);
        betweenBattle.ClosePowerupScreen();

    }
}
