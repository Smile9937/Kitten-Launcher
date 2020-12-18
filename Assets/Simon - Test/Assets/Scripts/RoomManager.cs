using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject doors;
    public float effectMultiplier;
    public int enemies;
    public bool spawnerInRoom = false;
    public bool roomCleared = false;

    public bool inCardSelectMenu = false;
    bool playerInRoom = false;
    bool tempName = false;
    public bool aquiredCard;
    WaveSpawner waveSpawners;
    PlayerController player;
    GameObject doorsInRoom;
    void Start()
    {
        waveSpawners = GetComponentInChildren<WaveSpawner>();
        player = FindObjectOfType<PlayerController>();
        player.rooms.Add(transform);

        if (waveSpawners != null)
        {

            spawnerInRoom = true;
        }

        InstantiateDoors();

        CloseDoors();
    }
    private void Update()

    {          Debug.Log(player.GetClosestRoom().spawnerInRoom);
        if (spawnerInRoom == false && enemies <= 0)
        {
  
            OpenDoors();
        } else
        {
            CloseDoors();
        }

        if (!inCardSelectMenu && spawnerInRoom && !roomCleared && playerInRoom)
        {
            if(!tempName)
            {
                tempName = true;
                spawnerInRoom = true;
                waveSpawners.canSpawn = true;
            }
        }
    }

    private void InstantiateDoors()
    {
        doorsInRoom = Instantiate(doors, transform.position, transform.rotation);
    }

    private void CloseDoors()
    {
        doorsInRoom.SetActive(true);
    }
    public void OpenDoors()
    {
        doorsInRoom.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && roomCleared == false)
        {
            playerInRoom = true;
        }
        if(other.CompareTag("Enemy"))
        {
            enemies++;
        }
    }
}
