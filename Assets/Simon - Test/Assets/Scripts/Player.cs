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
    Rigidbody2D myRigidbody;

    public float speedBonus;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Aim();
        if (cards.Count != 0) { speedBonus = cards[0].moveSpeedBonus * GetClosestRoom().effectMultiplier; }
    }

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
    private void Move()
    {
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");

        Vector2 playerVelocity = new Vector2(horizontalMove * (moveSpeed + speedBonus), verticalMove * (moveSpeed + speedBonus));
        myRigidbody.velocity = playerVelocity;
    }
    private void Aim()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

}
