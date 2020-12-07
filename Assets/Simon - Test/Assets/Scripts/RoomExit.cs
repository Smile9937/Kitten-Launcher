using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : MonoBehaviour
{
    [SerializeField] int direction;

    int teleport = 8;

    Player player;
    MoveCamera moveCamera;
    ShowMap showMap;
    void Start()
    {
        moveCamera = FindObjectOfType<MoveCamera>();
        player = FindObjectOfType<Player>();
        showMap = FindObjectOfType<ShowMap>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Bottom
            if (direction == 1)
            {
                moveCamera.Move(0f, -17f);
                player.transform.position += new Vector3(0, -teleport, 0);
                showMap.Invoke("MovePlayerIcon", 0.1f);
            }
            //Top
            else if (direction == 2)
            {
                moveCamera.Move(0f, 17);
                player.transform.position += new Vector3(0, teleport, 0);
                showMap.Invoke("MovePlayerIcon", 0.1f);
            }
            //Left
            else if (direction == 3)
            {
                moveCamera.Move(-29f, 0f);
                player.transform.position += new Vector3(-teleport, 0, 0);
                showMap.Invoke("MovePlayerIcon", 0.1f);
            }
            //Right
            else if (direction == 4)
            {
                moveCamera.Move(29f, 0f);
                player.transform.position += new Vector3(teleport, 0, 0);
                showMap.Invoke("MovePlayerIcon", 0.1f);
            }
        }
    }
}
