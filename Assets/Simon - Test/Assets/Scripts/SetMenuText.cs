using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMenuText : MonoBehaviour
{
    UnityEngine.UI.Text healthText;
    UnityEngine.UI.Text attackText;
    UnityEngine.UI.Text attackSpeedText;
    UnityEngine.UI.Text defenceText;
    UnityEngine.UI.Text movementSpeedText;

    PlayerController player;
    GameSession gameSession;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameSession = GameSession.Instance;

        healthText = gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        attackText = gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
        attackSpeedText = gameObject.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>();
        defenceText = gameObject.transform.GetChild(3).GetComponent<UnityEngine.UI.Text>();
        movementSpeedText = gameObject.transform.GetChild(4).GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        healthText.text = gameSession.playerHealth.ToString();
        attackText.text = player.attackDamage.ToString();
        attackSpeedText.text = player.attackSpeed.ToString();
        defenceText.text = player.defence.ToString();
        movementSpeedText.text = player.moveSpeed.ToString();
    }
}
