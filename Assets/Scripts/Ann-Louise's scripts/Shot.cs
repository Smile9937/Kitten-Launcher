using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    private Vector2 direction;
    void Start()
    {
        direction = GameObject.Find("Direction").transform.position;
        transform.position = GameObject.Find("Firepoint").transform.position;
        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Player").transform.eulerAngles.z);
        Destroy(gameObject, 2f);
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);

    }
}