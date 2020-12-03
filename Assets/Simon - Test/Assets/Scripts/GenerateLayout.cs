using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLayout : MonoBehaviour
{
    [SerializeField] Room[] roomEdits;
    Vector3[] position;

    GameObject currentRoom;

    void Start()
    {
        Generate();
    }

    private void Generate()
    {
        position = new Vector3[roomEdits.Length];

        for(int i = 0; i < roomEdits.Length; i++)
        {
            Vector3 roomPosition = new Vector3(roomEdits[i].positionX, roomEdits[i].positionY, transform.position.z);
            position = new Vector3[roomEdits.Length];
            position[i] = new Vector3(roomPosition.x * roomEdits[i].roomWidth, roomPosition.y * roomEdits[i].roomHeight, roomPosition.z);

            currentRoom = roomEdits[i].roomArrays.rooms[UnityEngine.Random.Range(0, roomEdits[i].roomArrays.rooms.Length-1)];
            Instantiate(currentRoom, position[i], transform.rotation);
        }
    }
}
