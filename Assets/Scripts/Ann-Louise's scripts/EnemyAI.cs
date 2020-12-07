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

    [SerializeField] UnityEngine.GameObject projectile;

    float fireRate = 1f;
    float nextFire;
    
    void Start()
    {
        // Checking when it's time to fire/attack
        nextFire = Time.time;

        Player = UnityEngine.GameObject.FindGameObjectWithTag("Player").transform;
        
        
    }

    void Update()
    {
        if(Player != null)
        {
        transform.LookAt(Player);
        ChasePlayer();
        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            AttackPlayer();
        }
        }
    }

    private void ChasePlayer()
    {
            if (Player != null)
            {
                if (Vector3.Distance(transform.position, Player.position) >= MinDist)
                {
                 transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                Debug.Log("Looking at player");
                }
                    
            }
        
    }

    void AttackPlayer()
    {
        if(Time.time > nextFire)
        {
            //Creating the projectile and then resetting the nextfire
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

}




