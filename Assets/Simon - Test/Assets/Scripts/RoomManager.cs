using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public float effectMultiplier;
    GenerateLayout generateLayout;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.rooms.Add(transform);
        generateLayout = FindObjectOfType<GenerateLayout>();
        CloseDoors();
    }

    private void CloseDoors()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OpenDoors()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

}
