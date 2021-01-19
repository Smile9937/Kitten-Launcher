using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowMenuScreen : MonoBehaviour
{
    [SerializeField] GameObject menuScreen;
    [SerializeField] GameObject[] cards;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject backButton;

    public bool menuToggle = false;
    bool spawnersCanSpawn = false;

    float[] position;

    PlayerController player;
    WaveSpawner waveSpawners;
    EnemyAI[] enemies;
    Heart[] hearts;
    ShowMap showMap;
    GameSession gameSession;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        showMap = FindObjectOfType<ShowMap>();
        gameSession = GameSession.Instance;
    }

    void Update()
    {
        if (Input.GetButtonDown("Toggle Menu Screen") && !showMap.mapToggle)
        {
            if (!menuToggle)
            {
                OpenMenu();
            }
            else if (menuToggle)
            {
                CloseMenu();
            }
        }
    }

    private void OpenMenu()
    {
        menuToggle = !menuToggle;

        waveSpawners = player.GetClosestRoom().GetComponentInChildren<WaveSpawner>();
        if (waveSpawners != null)
        {
            if (waveSpawners.canSpawn == true) { spawnersCanSpawn = true; }
            waveSpawners.canSpawn = false;
        }

        enemies = FindObjectsOfType<EnemyAI>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].TogglePause();
        }
        hearts = FindObjectsOfType<Heart>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].TogglePause();
        }
        player.TogglePause();

        gameSession.HideCanvas();
        menuScreen.SetActive(true);

        InstantiateCards();

        GameObject quit = Instantiate(quitButton, Vector3.zero, transform.rotation);
        quit.transform.SetParent(menuScreen.transform, false);

        RectTransform rectTransform = quit.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(-330, 200);

        GameObject back = Instantiate(backButton, Vector3.zero, transform.rotation);
        back.transform.SetParent(menuScreen.transform, false);

        RectTransform rectTransform1 = back.GetComponent<RectTransform>();
        rectTransform1.anchoredPosition = new Vector2(330, -200);
    }

    private void InstantiateCards()
    {
        List<Cards> cardList = player.cards;
        if (cardList.Count - 1 == 0)
        {
            GameObject cardInstance = Instantiate(cards[cardList[0].id], Vector3.zero, transform.rotation);
            cardInstance.transform.SetParent(menuScreen.transform, false);

            RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(110, 70);
        }
        else
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                Vector2[] position = new Vector2[10];

                position[0] = new Vector2(110f, 70f);
                position[1] = new Vector2(160f, 70f);
                position[2] = new Vector2(210f, 70f);
                position[3] = new Vector2(260f, 70f);
                position[4] = new Vector2(310f, 70f);
                position[5] = new Vector2(110f, -70f);
                position[6] = new Vector2(160f, -70f);
                position[7] = new Vector2(210f, -70f);
                position[8] = new Vector2(260f, -70f);
                position[9] = new Vector2(310f, -70f);


                GameObject cardInstance = Instantiate(cards[cardList[i].id], Vector3.zero, transform.rotation);
                cardInstance.transform.SetParent(menuScreen.transform, false);

                RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = position[i];
            }
        }
    }

    public void CloseMenu()
    {
        menuToggle = !menuToggle;
        gameSession.OpenCanvas();

        if (spawnersCanSpawn)
        {
            waveSpawners = player.GetClosestRoom().GetComponentInChildren<WaveSpawner>();
            waveSpawners.canSpawn = true;
        }

        enemies = FindObjectsOfType<EnemyAI>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].TogglePause();
        }

        hearts = FindObjectsOfType<Heart>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].TogglePause();
        }

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        player.TogglePause();

        GameObject[] cardPrefabs = GameObject.FindGameObjectsWithTag("MenuPrefab");
        if (cardPrefabs.Length - 1 == 0 && cardPrefabs[0] != null)
        {
            if (cardPrefabs[0] != null)
            {
                Destroy(cardPrefabs[0]);
            }
        }
        else
        {
            for (int i = 0; i < cardPrefabs.Length; i++)
            {
                Destroy(cardPrefabs[i]);
            }
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i]);
        }

        menuScreen.SetActive(false);
    }
}
