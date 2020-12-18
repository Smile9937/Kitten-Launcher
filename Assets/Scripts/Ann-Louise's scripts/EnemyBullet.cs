using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] int bulletRotation = 90;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] bool homing;
    [SerializeField] bool rotating;
    Rigidbody2D myRigidbody2D;

    PlayerController target;
    public Vector3 moveDirection;

    float rotationspeed = 10f;

    public Vector3 rotationTarget;
    public bool targetPlayer = true;
    public Vector3 randomAttackSpread = new Vector3(0, 0, 0);
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>();
      
        if (targetPlayer) {
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            rotationTarget = target.transform.position;
        }
        Vector3 targetDirection = new Vector3(moveDirection.x, moveDirection.y, transform.position.z) + randomAttackSpread;
        myRigidbody2D.velocity = targetDirection;
        Destroy(gameObject, 3f);

        if(targetPlayer)
        {
            Vector3 direction = rotationTarget - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x);
            transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - bulletRotation);
        } else
        {
            Vector3 direction = rotationTarget;
            float angle = Mathf.Atan2(direction.y, direction.x);
            transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - bulletRotation);
        }



    }
    private void Update()
    {
        if(rotating)
        {
            float rotation = rotationspeed * Time.deltaTime;
            rotation++;
            transform.Rotate(0, 0, rotation, Space.Self);
        }

        if(homing)
        {
            var homeMoveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            Vector3 targetDirection = new Vector3(homeMoveDirection.x, homeMoveDirection.y, transform.position.z);
            myRigidbody2D.velocity = targetDirection;
            Invoke("StopHoming", 0.65f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);           
        }
    }
    void StopHoming()
    {
        homing = false;
    }
}
