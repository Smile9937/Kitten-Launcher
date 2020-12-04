using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos != null)
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z - 10);
        }
       
    }
}

