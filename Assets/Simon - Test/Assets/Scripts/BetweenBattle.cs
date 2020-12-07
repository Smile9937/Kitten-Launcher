using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenBattle : MonoBehaviour
{
    [SerializeField] GameObject powerUpScreen;
    [SerializeField] GameObject[] cardPrefabs;
    [SerializeField] GameObject powerupScreen;
    int index;
    float[] position;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        powerUpScreen.SetActive(false);
    }

    public void OpenPowerupScreen()
    {
        player.moveSpeed = 0;
        powerUpScreen.SetActive(true);

        position = new float[cardPrefabs.Length];

        List<int> list = new List<int>();

        for (int i = 0; i < cardPrefabs.Length + 1; i++)
        {
            list.Add(i);
        }

        for(int i = 0; i < 3; i++)
        {
            position = new float[cardPrefabs.Length];

            position[0] = -220f;
            position[1] = 0f;
            position[2] = 220f;

            index = Random.Range(0, list.Count - 1);
            int currentCard = list[index];
            list.RemoveAt(index);


            GameObject cardInstance = Instantiate(cardPrefabs[currentCard], Vector3.zero, transform.rotation);
            cardInstance.transform.SetParent(powerUpScreen.transform, false);

            RectTransform rectTransform = cardInstance.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(position[i], 0f);
        }
    }

    public void ClosePowerupScreen()
    {
        player.moveSpeed = player.startMoveSpeed;
        powerUpScreen.SetActive(false);
    }
}
