﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenBattle : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject discardScreen;
    [SerializeField] List<GameObject> lootPrefabs;

    [SerializeField] GameObject[] tier1LootPrefabs;
    [SerializeField] GameObject[] tier2LootPrefabs;
    [SerializeField] GameObject[] tier3LootPrefabs;
    [SerializeField] GameObject[] tier4LootPrefabs;

    [SerializeField] GameObject[] cards;
    [SerializeField] GameObject closeButton;
    int index;
    float[] position;
    public bool canOpenVictoryScreen = true;
    public bool canOpenDiscardScreen = true;
    PlayerController player;
    GameSession gameSession;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameSession = GameSession.Instance;
        victoryScreen.SetActive(false);
        discardScreen.SetActive(false);
    }
    
    public void OpenPowerupScreen()
    {
        if (canOpenVictoryScreen)
        {
            gameSession.HideCanvas();
            canOpenVictoryScreen = false;
            player.moveSpeed = 0;
            victoryScreen.SetActive(true);

            position = new float[3];

            for (int i = 0; i < 3; i++)
            {
                position = new float[3];

                position[0] = -220f;
                position[1] = 0f;
                position[2] = 220f;

                RandomizRarity(i);

                GameObject cardInstance = Instantiate(lootPrefabs[i], Vector3.zero, transform.rotation);
                cardInstance.transform.SetParent(victoryScreen.transform, false);

                RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(position[i], -30f);
            }
            Invoke("Cooldown", 1);
        }
    }

    private void RandomizRarity(int index)
    {
        var rarityIndex = Random.Range(0, 19);

        switch (rarityIndex)
        {
            case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9:
                lootPrefabs.Add(tier1LootPrefabs[index]);
                break;
            case 10: case 11: case 12: case 13: case 14: case 15:
                lootPrefabs.Add(tier2LootPrefabs[index]);
                break;
            case 16: case 17: case 18:
                lootPrefabs.Add(tier3LootPrefabs[index]);
                break;
            case 19:
                lootPrefabs.Add(tier4LootPrefabs[index]);
                break;
        }
    }

    public void OpenChooseCard()
    {
        if (canOpenDiscardScreen)
        {
            gameSession.HideCanvas();
            canOpenDiscardScreen = false;
            List<Cards> cardList = player.cards;
            discardScreen.SetActive(true);
            player.moveSpeed = 0;

            if(cardList.Count - 1 == 0)
            {
                GameObject cardInstance = Instantiate(cards[cardList[0].id], Vector3.zero, transform.rotation);
                cardInstance.transform.SetParent(discardScreen.transform, false);

                RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(-280, -30);
            } else
            {
                for (int i = 0; i < cardList.Count; i++)
                {
                    position = new float[10];

                    position[0] = -340f;
                    position[1] = -265f;
                    position[2] = -190f;
                    position[3] = -115f;
                    position[4] = -40f;
                    position[5] = 35f;
                    position[6] = 110f;
                    position[7] = 185f;
                    position[8] = 260f;
                    position[9] = 335f;
                    

                    GameObject cardInstance = Instantiate(cards[cardList[i].id], Vector3.zero, transform.rotation);
                    cardInstance.transform.SetParent(discardScreen.transform, false);

                    RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(position[i], -30f);
                }
            }

            GameObject close = Instantiate(closeButton, Vector3.zero, transform.rotation);
            close.transform.SetParent(discardScreen.transform, false);

            RectTransform rectTransform1 = close.GetComponent<RectTransform>();
            rectTransform1.anchoredPosition = new Vector2(330, -200);
            Invoke("Cooldown2", 1f);
        }

    }

    public void ClosePowerupScreen()
    {
        GameObject[] cardPrefabs = GameObject.FindGameObjectsWithTag("LootPrefab");
        player.moveSpeed = player.startingMoveSpeed;
        victoryScreen.SetActive(false);
        for(int i = 0; i < cardPrefabs.Length; i++)
        {
            Destroy(cardPrefabs[i]);
        }

        for(int i = 0; i < lootPrefabs.Count + 1; i++)
        {
            lootPrefabs.RemoveAt(i);
        }
    }

    public void CloseDiscardCard()
    {
        player.moveSpeed = player.startingMoveSpeed;
        player.GetClosestRoom().inCardSelectMenu = false;
        Invoke("Test", 1f);


        GameObject[] cardPrefabs = GameObject.FindGameObjectsWithTag("LootPrefab");
        GameObject button = GameObject.FindGameObjectWithTag("Button");
        discardScreen.SetActive(false);
        if(cardPrefabs.Length - 1 == 0 && cardPrefabs[0] != null) {
            if(cardPrefabs[0] != null)
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
        Destroy(button);
    }
    void Test()
    {
        player.GetClosestRoom().inCardSelectMenu = false;
    }
    void Cooldown()
    {
        canOpenVictoryScreen = true;
    }    
    void Cooldown2()
    {
        canOpenDiscardScreen = true;
    }
}
