using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowMenuScreen : MonoBehaviour
{
    [SerializeField] GameObject menuScreen;
    [SerializeField] Image[] cardImages;

    public bool menuToggle = false;
    bool spawnersCanSpawn = false;

    PlayerController player;
    WaveSpawner waveSpawners;
    EnemyAI[] enemies;
    Heart[] hearts;
    ShowMap showMap;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        showMap = FindObjectOfType<ShowMap>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Toggle Menu Screen") && !showMap.mapToggle)
        {
            Debug.Log("Got here");
            menuToggle = !menuToggle;

            if (menuToggle)
            {
                OpenMenu();
            }
            else if (!menuToggle)
            {
                CloseMenu();
            }
        }
    }

    private void OpenMenu()
    {
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
        menuScreen.SetActive(true);
    }

    private void CloseMenu()
    {
        if(spawnersCanSpawn)
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

        player.TogglePause();
        menuScreen.SetActive(false);
    }
}
