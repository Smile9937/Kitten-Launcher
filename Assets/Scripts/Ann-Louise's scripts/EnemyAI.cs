using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{ 
    private Transform Player;
    
    [SerializeField] int MoveSpeed = 4;
    [SerializeField] int MaxDist = 10;
    [SerializeField] int MinDist = 5;

    GameObject projectile;

    float fireRate = 1f;
    float nextFire;
    
    void Start()
    {
        nextFire = Time.time;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(Player);
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            Debug.Log("Looking at player");



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                AttackPlayer();
            }

        }
    }

    void AttackPlayer()
    {
        if(Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

}




