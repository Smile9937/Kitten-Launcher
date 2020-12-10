using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenBattle : MonoBehaviour
{
    [SerializeField] GameObject powerUpScreen;
    [SerializeField] GameObject[] lootPrefabs;
    [SerializeField] GameObject[] cards;
    [SerializeField] GameObject powerupScreen;
    [SerializeField] GameObject closeButton;
    int index;
    float[] position;
    bool canOpenScreen = true;
    bool canOpenScreen2 = true;
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        powerUpScreen.SetActive(false);
    }

    public void OpenPowerupScreen()
    {
        if (canOpenScreen)
        {
            canOpenScreen = false;
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
                rectTransform.anchoredPosition = new Vector2(position[i], 0f);
            }
            Invoke("Cooldown", 1);
        }
    }

    public void OpenChooseCard()
    {        if(canOpenScreen2)
        {
            canOpenScreen2 = false;
            List<Cards> cardList = player.cards;
            powerUpScreen.SetActive(true);
            player.moveSpeed = 0;
            position = new float[cardList.Count - 1];


            Debug.Log(cardList.Count);

            if(cardList.Count - 1 == 0)
            {
                GameObject cardInstance = Instantiate(cards[cardList[0].id], Vector3.zero, transform.rotation);
                Debug.Log(cardList[0].id.ToString());
                cardInstance.transform.SetParent(powerUpScreen.transform, false);

                RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(-220, 0f);
            } else
            {
                for (int i = 0; i < cardList.Count; i++)
                {
                    position = new float[cardList.Count + 1];

                    position[0] = -220f;
                    position[1] = 0f;
                    position[2] = 220f;

                    GameObject cardInstance = Instantiate(cards[cardList[i].id], Vector3.zero, transform.rotation);
                    Debug.Log(cardList[i].id.ToString());
                    cardInstance.transform.SetParent(powerUpScreen.transform, false);

                    RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(position[i], 0f);
                }
            }

            GameObject close = Instantiate(closeButton, Vector3.zero, transform.rotation);
            close.transform.SetParent(powerUpScreen.transform, false);

            RectTransform rectTransform1 = close.GetComponent<RectTransform>();
            rectTransform1.anchoredPosition = new Vector2(350, -150);
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

    public void CloseChooseCard()
    {
        player.moveSpeed = player.startMoveSpeed;
        Invoke("Test", 0.1f);


        var cardPrefabs = GameObject.FindGameObjectsWithTag("LootPrefab");
        var quitButton = GameObject.FindGameObjectWithTag("QuitButton");
        powerUpScreen.SetActive(false);
        Debug.Log(cardPrefabs.Length);
        if(cardPrefabs.Length == 0) { Destroy(cardPrefabs[0]); }
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
        canOpenScreen = true;
    }    
    void Cooldown2()
    {
        canOpenScreen = true;
    }
}
