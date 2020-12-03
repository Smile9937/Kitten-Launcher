﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : MonoBehaviour
{
    [SerializeField] int direction;

    int teleport = 6;
    bool powerupCollected = false;

    Player player;
    MoveCamera moveCamera;
    BetweenBattle betweenBattle;
    void Start()
    {
        moveCamera = FindObjectOfType<MoveCamera>();
        player = FindObjectOfType<Player>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            /*if (powerupCollected == false)
            {
                powerupCollected = true;

                betweenBattle.OpenPowerupScreen();

            }*/
                //Bottom
                if (direction == 1)
                {
                    moveCamera.Move(0f, -17f);
                    player.transform.position += new Vector3(0, -teleport, 0);
                }
                //Top
                else if(direction == 2)
                {
                    moveCamera.Move(0f, 17);
                    player.transform.position += new Vector3(0, teleport, 0);
                }
                //Left
                else if (direction == 3)
                {
                    moveCamera.Move(-29f, 0f);
                    player.transform.position += new Vector3(-teleport, 0, 0);
                }
                //Right
                else if (direction == 4)
                {
                    moveCamera.Move(29f, 0f);
                    player.transform.position += new Vector3(teleport, 0, 0);
                }

        }
    }




    void Update()
    {
        
    }
}
