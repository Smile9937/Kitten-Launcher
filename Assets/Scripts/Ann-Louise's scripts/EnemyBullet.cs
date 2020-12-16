using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float moveSpeed = 10f;
    Rigidbody2D myRigidbody2D;

    PlayerController target;
    public Vector3 moveDirection;

    public Vector3 rotationTarget;
    public bool targetPlayer = true;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>();
      
        if (targetPlayer) {
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            rotationTarget = target.transform.position;
        }
        Vector3 targetDirection = new Vector3(moveDirection.x, moveDirection.y, transform.position.z);
        myRigidbody2D.velocity = targetDirection;
        Destroy(gameObject, 3f);

        Vector3 direction = rotationTarget - transform.position; float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - 90);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);           
        }
    }
}
