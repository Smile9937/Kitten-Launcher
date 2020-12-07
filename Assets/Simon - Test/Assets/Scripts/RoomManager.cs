using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject doors;
    public float effectMultiplier;
    public int enemies;
    Player player;
    GameObject doorsInRoom;
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.rooms.Add(transform);
        InstantiateDoors();
        CloseDoors();
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
        if(other.CompareTag("Enemy"))
        {
            enemies++;
        }
    }
}
