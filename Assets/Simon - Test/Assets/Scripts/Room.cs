using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room")]
public class Room : ScriptableObject
{
    public RoomArray roomArrays;
    public float roomWidth;
    public float roomHeight;
    public float positionX;
    public float positionY;
}
