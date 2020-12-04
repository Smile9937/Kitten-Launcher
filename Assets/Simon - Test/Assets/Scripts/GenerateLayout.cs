using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLayout : MonoBehaviour
{
    [SerializeField] Room[] roomEdits;
    [SerializeField] float roomWidth;
    [SerializeField] float roomHeight;
    public float[] effectMultiplier;
    Vector3[] position;

    int index;
    public int currentEffectMultiplier;
    RoomManager currentRoom;

    void Start()
    {
        Generate();
    }

    private void Generate()
    {
        List<int> list = new List<int>();

        for (int i = 0; i < effectMultiplier.Length + 1; i++)
        {
            list.Add(i);
        }

        position = new Vector3[roomEdits.Length];

        for(int i = 0; i < roomEdits.Length; i++)
        {
            index = UnityEngine.Random.Range(0, list.Count - 1);
            currentEffectMultiplier = list[index];
            list.RemoveAt(index);

            Vector3 roomPosition = new Vector3(roomEdits[i].positionX, roomEdits[i].positionY, transform.position.z);
            position = new Vector3[roomEdits.Length];
            position[i] = new Vector3(roomPosition.x * roomWidth, roomPosition.y * roomHeight, roomPosition.z);

            currentRoom = roomEdits[i].roomArrays.rooms[UnityEngine.Random.Range(0, roomEdits[i].roomArrays.rooms.Length-1)];
            RoomManager roomPrefab = Instantiate(currentRoom, position[i], transform.rotation);

            roomPrefab.effectMultiplier = currentEffectMultiplier;
        }
    }
}
