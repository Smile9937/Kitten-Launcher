using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text healthText;
    public List<Cards> playerCards;
    public Weapon currentPlayerWeapon;
    public float playerHealth;
    public int level = 0;
    float passiveHealthBonus;

    public List<Rigidbody2D> EnemyRbs;

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
        ChangeHealthText();
    }

    public float GetPlayerHealth()
    {
        return playerHealth;
    }

    public void IncreasePlayerHealth(float healthIncrease)
    {
        playerHealth += healthIncrease;
        ChangeHealthText();
    }

    public void DecreasePlayerHealth(float healthDecrease)
    {
        playerHealth -= healthDecrease;
        ChangeHealthText();
    }

    public void ChangeHealthText()
    {
        if (this != null) { healthText.text = playerHealth.ToString(); }
    }

    public void HideCanvas()
    {
        if (this != null)
        {
            GameObject canvas = gameObject.transform.GetChild(0).gameObject;
            canvas.SetActive(false);
        }
    }
    public void OpenCanvas()
    {
        if (this!= null)
        {
            GameObject canvas = gameObject.transform.GetChild(0).gameObject;
            canvas.SetActive(true);
        }
    }
}
