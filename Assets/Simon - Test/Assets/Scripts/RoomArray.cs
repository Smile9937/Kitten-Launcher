﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Room Array")]
public class RoomArray : ScriptableObject
{
    public RoomManager[] rooms;
    public int roomType;
}
