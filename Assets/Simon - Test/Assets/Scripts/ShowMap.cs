﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour
{
    [SerializeField] GameObject mapScreen;
    [SerializeField] float mapPositionX = 20f;
    [SerializeField] float mapPositionY = 20f;
    [SerializeField] GameObject playerIcon;
    public GameObject[] mapIcons;
    public List<Vector3> mapPositions;
    public List<int> roomType;
    public List<float> roomText;

    GameObject playerIconInstance;

    bool mapToggle = false;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Toggle Map"))
        {
            mapToggle = !mapToggle;

            if(mapToggle)
            {
                player.moveSpeed = 0;
                OpenMap();
            } 
            else if(!mapToggle)
            {
                player.moveSpeed = player.startMoveSpeed;
                CloseMap();
            }
        }
    }

    public void OpenMap()
    {
        mapScreen.SetActive(true);
    }
    public void CloseMap()
    {
        mapScreen.SetActive(false);
    }

    public void GenerateMap()
    {
        for(int i = 0; i < roomType.Count; i++)
        {
            GameObject mapIconInstance = Instantiate(mapIcons[roomType[i]], Vector3.zero, transform.rotation);
            mapIconInstance.transform.SetParent(mapScreen.transform, false);

            UnityEngine.UI.Text currentEffectText = mapIconInstance.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();

            currentEffectText.text = roomText[i].ToString();

            RectTransform rectTransform = mapIconInstance.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector3.Scale(mapPositions[i] - new Vector3(mapPositionX, mapPositionY, 0), new Vector3(2.5f, 4.2f, 0));
        }

        playerIconInstance = Instantiate(playerIcon, Vector3.zero, transform.rotation);
        playerIconInstance.transform.SetParent(mapScreen.transform, false);

        Invoke("MovePlayerIcon", 0.1f);
    }
    
    public void MovePlayerIcon()
    {
        RectTransform playerIconRect = playerIconInstance.GetComponent<RectTransform>();
        playerIconRect.anchoredPosition = Vector3.Scale(player.GetClosestRoom().transform.position - new Vector3(mapPositionX + 5, mapPositionY + 4, 0), new Vector3(2.5f, 4.2f, 0));
    }
}