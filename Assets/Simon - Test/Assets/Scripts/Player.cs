using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Cards>cards;

    public List<Transform> rooms;

    public float startMoveSpeed = 10f;
    public float moveSpeed = 10f;

    public float speedBonus;
    public RoomManager GetClosestRoom()
    {
        RoomManager closestRoom = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in rooms)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestRoom = potentialTarget.GetComponent<RoomManager>();
            }
        }
        return closestRoom;
    }

}
