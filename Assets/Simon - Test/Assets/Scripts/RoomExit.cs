using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : MonoBehaviour
{
    [SerializeField] int direction;

    int teleport = 5;

    bool canOpenMenu = true;

    Vector3 nextPos;

    List<Transform> rooms;

    PlayerController player;
    MoveCamera moveCamera;
    ShowMap showMap;
    BetweenBattle betweenBattle;
    void Start()
    {
        moveCamera = FindObjectOfType<MoveCamera>();
        player = FindObjectOfType<PlayerController>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
        showMap = FindObjectOfType<ShowMap>();
        rooms = player.rooms;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(canOpenMenu)
            {
                canOpenMenu = false;
                //Bottom
                if (direction == 1)
                {                
                    moveCamera.Move(0f, -18f);
                    nextPos = new Vector3(0, -teleport, 0);
                    player.transform.position += nextPos;
                    OpenCardSelect();
                }
                //Top
                else if (direction == 2)
                {
                    moveCamera.Move(0f, 18);
                    nextPos = new Vector3(0, teleport, 0);
                    player.transform.position += nextPos;
                    OpenCardSelect();
                }
                //Left
                else if (direction == 3)
                {
                    moveCamera.Move(-30f, 0f);
                    nextPos = new Vector3(-teleport, 0, 0);
                    player.transform.position += nextPos;
                    OpenCardSelect();
                }
                //Right
                else if (direction == 4)
                {
                    moveCamera.Move(30f, 0f);
                    nextPos = new Vector3(teleport, 0, 0);
                    player.transform.position += nextPos;
                    OpenCardSelect();
                }
            }
        }
    }

    private void OpenCardSelect()
    {
        showMap.Invoke("MovePlayerIcon", 0.1f);
        if(player.GetClosestRoom().spawnerInRoom) {
            player.GetClosestRoom().inCardSelectMenu = true;
            betweenBattle.OpenChooseCard();
        }
        player.ResetStats();
        Invoke("MenuCooldown", 0.1f);
    }

    void MenuCooldown()
    {
        canOpenMenu = true;
    }
}
