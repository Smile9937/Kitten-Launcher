using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] Transform middleOfRoom;
    [SerializeField] EnemyBullet[] projectiles;
    [SerializeField] float moveSpeed = 2f;
    public float fireRate = 1f;
    public int shots = 0;
    int waypointIndex = 0;
    bool attack2;
    float nextFire;
    bool changeBulletDir = false;
    float halfHealth;
    bool waitForPlayer = true;
    EnemyBullet currentProjectile;
    Enemy enemy;
    PlayerController target;
    void Start()
    {
        target = FindObjectOfType<PlayerController>();
        enemy = GetComponent<Enemy>();
        nextFire = Time.time;
        halfHealth = enemy.startHealth / 2;
        transform.position = waypoints[waypointIndex].transform.position;
        Invoke("WaitForPlayer", 0.5f);
    }
    void Update()
    {
        if(target != null && !waitForPlayer)
        {
            FlipSprite();
            Move();
        }
    }

    private void FlipSprite()
    {
        Vector3 targetPosition = transform.position - target.transform.position;

        float check = Mathf.Sign(targetPosition.x);
        float localScaleCheck = Mathf.Sign(transform.localScale.x);
        transform.localScale = new Vector2(check * transform.localScale.x * localScaleCheck, transform.localScale.y);
    }
    private void Move()
    {

        if(enemy.health == halfHealth && !attack2)
        {
            halfHealth = enemy.health / 2;
            Invoke("ReturnToFirstAttack", 8f);
            attack2 = true;
            fireRate *= 2;
            nextFire = Time.time + fireRate;
        }
        else if(!attack2)
        {
            if(waypointIndex <= waypoints.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex++;
                }
            }
            else
            {
                waypointIndex = 0;
            }

            Attack1();
        }
        else if(attack2)
        {
            Attack2();
        }

    }

    private void Attack1()
    {
        currentProjectile = projectiles[UnityEngine.Random.Range(0, projectiles.Length)];
        if (Time.time > nextFire)
        {
            //Creating the projectile and then resetting the nextfire
            Instantiate(currentProjectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void Attack2()
    {
        transform.position = Vector2.MoveTowards(transform.position, middleOfRoom.transform.position, moveSpeed * Time.deltaTime);

        if (Time.time > nextFire && transform.position == middleOfRoom.transform.position)
        {
            Debug.Log("Got here");
            for(int i = 0; i < shots; i++)
            {
                currentProjectile = projectiles[UnityEngine.Random.Range(0, projectiles.Length)];
                Vector2[] bulletDir = new Vector2[8];

                if (!changeBulletDir) { Directions1(bulletDir); }
                if (changeBulletDir) { Directions2(bulletDir); }

                EnemyBullet bullet = Instantiate(currentProjectile, new Vector3(transform.position.x + bulletDir[i].x, transform.position.y + bulletDir[i].y, transform.position.z), transform.rotation);
                Vector3 direction = new Vector3(transform.position.x + bulletDir[i].x * 5, transform.position.y + bulletDir[i].y * 5, transform.position.z);
                bullet.moveDirection = direction;
                bullet.targetPlayer = false;
                bullet.rotationTarget = direction;


                nextFire = Time.time + fireRate;
            }
            changeBulletDir = !changeBulletDir;

        }
    }

    void ReturnToFirstAttack()
    {
        attack2 = false;
        fireRate /= 2;
    }

    void WaitForPlayer()
    {
        waitForPlayer = false;
    }
    private void Directions1(Vector2[] bulletDir)
    {
        bulletDir[0] = new Vector2(1f, 0f);
        bulletDir[1] = new Vector2(1f, -1f);
        bulletDir[2] = new Vector2(0f, -1f);
        bulletDir[3] = new Vector2(-1f, -1f);
        bulletDir[4] = new Vector2(-1f, 0f);
        bulletDir[5] = new Vector2(-1f, 1f);
        bulletDir[6] = new Vector2(0f, 1f);
        bulletDir[7] = new Vector2(1f, 1f);
    }
    private void Directions2(Vector2[] bulletDir)
    {
        bulletDir[0] = new Vector2(1f, -0.5f);
        bulletDir[1] = new Vector2(0.5f, -1f);
        bulletDir[2] = new Vector2(-0.5f, -1f);
        bulletDir[3] = new Vector2(-1f, -0.5f);
        bulletDir[4] = new Vector2(-1f, 0.5f);
        bulletDir[5] = new Vector2(-0.5f, 1f);
        bulletDir[6] = new Vector2(0.5f, 1f);
        bulletDir[7] = new Vector2(1f, 0.5f);
    }
}
