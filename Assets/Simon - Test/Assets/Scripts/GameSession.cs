using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text healthText;
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
        ChangeHealthText();
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

    public void ChangeHealthText()
    {
        healthText.text = playerHealth.ToString();
    }

    public void HideCanvas()
    {
        GameObject canvas = gameObject.transform.GetChild(0).gameObject;
        canvas.SetActive(false);
    }
    public void OpenCanvas()
    {
        GameObject canvas = gameObject.transform.GetChild(0).gameObject;
        canvas.SetActive(true);
    }
}
