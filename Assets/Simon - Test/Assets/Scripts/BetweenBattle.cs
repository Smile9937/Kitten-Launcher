using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenBattle : MonoBehaviour
{
    [SerializeField] GameObject powerUpScreen;
    [SerializeField] GameObject discardScreen;
    [SerializeField] GameObject[] lootPrefabs;
    [SerializeField] GameObject[] cards;
    [SerializeField] GameObject closeButton;
    int index;
    float[] position;
    public bool canOpenPowerupScreen = true;
    public bool canOpenDiscardScreen = true;
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        powerUpScreen.SetActive(false);
        discardScreen.SetActive(false);
    }

    public void OpenPowerupScreen()
    {
        if (canOpenPowerupScreen)
        {
            canOpenPowerupScreen = false;
            player.moveSpeed = 0;
            powerUpScreen.SetActive(true);

            position = new float[3];

            List<int> list = new List<int>();

            for (int i = 0; i < lootPrefabs.Length + 1; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                position = new float[3];

                position[0] = -220f;
                position[1] = 0f;
                position[2] = 220f;

                index = Random.Range(0, list.Count - 1);
                int currentLoot = list[index];
                list.RemoveAt(index);


                GameObject cardInstance = Instantiate(lootPrefabs[currentLoot], Vector3.zero, transform.rotation);
                cardInstance.transform.SetParent(powerUpScreen.transform, false);

                RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(position[i], -30f);
            }
            Invoke("Cooldown", 1);
        }
    }

    public void OpenChooseCard()
    {        if(canOpenDiscardScreen)
        {
            canOpenDiscardScreen = false;
            List<Cards> cardList = player.cards;
            discardScreen.SetActive(true);
            player.moveSpeed = 0;
            position = new float[cardList.Count + 1];



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
                    position = new float[cardList.Count + 1];

                    position[0] = -280f;
                    position[1] = -210f;
                    position[2] = -140f;
                    position[3] = -70f;
                    position[4] = 0f;
                    position[5] = 70f;
                    position[6] = 140f;
                    position[7] = 210f;
                    position[8] = 280f;
                    

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
        var cardPrefabs = GameObject.FindGameObjectsWithTag("LootPrefab");
        player.moveSpeed = player.startMoveSpeed;
        powerUpScreen.SetActive(false);
        for(int i = 0; i < cardPrefabs.Length; i++)
        {
            Destroy(cardPrefabs[i]);
        }
    }

    public void CloseDiscardCard()
    {
        player.moveSpeed = player.startMoveSpeed;
        player.GetClosestRoom().inCardSelectMenu = false;
        Invoke("Test", 1f);


        var cardPrefabs = GameObject.FindGameObjectsWithTag("LootPrefab");
        var quitButton = GameObject.FindGameObjectWithTag("QuitButton");
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
        Destroy(quitButton);
    }
    void Test()
    {
        player.GetClosestRoom().inCardSelectMenu = false;
    }
    void Cooldown()
    {
        canOpenPowerupScreen = true;
    }    
    void Cooldown2()
    {
        canOpenDiscardScreen = true;
    }
}
