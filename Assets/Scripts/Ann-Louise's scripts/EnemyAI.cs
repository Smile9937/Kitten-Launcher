using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{ 
    private Transform Player;
    [SerializeField] int enemyIndex;
    [SerializeField] float MoveSpeed = 4f;
    [SerializeField] int MaxDist = 10;
    [SerializeField] int MinDist = 5;

    [SerializeField] GameObject projectile;
    [SerializeField] bool moving;
    [SerializeField] bool attackAnimation;
    Vector3 velocity;
    Vector3 previous;

    public float fireRate = 1f;
    float nextFire;
    bool waitForPlayer = true;
    Animator animator;
    Enemy enemy;
    SoundLibrary soundLibrary;
    void Start()
    {
        animator = GetComponent<Animator>();
        // Checking when it's time to fire/attack
        nextFire = Time.time;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
        soundLibrary = FindObjectOfType<SoundLibrary>();
        Invoke("WaitForPlayer", 0.5f);
    }

    void Update()
    {
        if (Player != null && !waitForPlayer)
        {
            if(moving)
            {
              ChasePlayer();
            }
          
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        
            AttackPlayer();
        
            bool hasHorizontalSpeed = Mathf.Abs(velocity.x) > Mathf.Epsilon;

            if (hasHorizontalSpeed)
            {
                float xVelocity = Mathf.Sign(velocity.x);
                float localScaleCheck = -Mathf.Sign(transform.localScale.x);
                transform.localScale = new Vector2(xVelocity * transform.localScale.x * localScaleCheck, transform.localScale.y);
            }
        }
    }

    private void ChasePlayer()
    {
            if (Player != null)
            {
                if (Vector3.Distance(transform.position, Player.position) >= MinDist)
                {
                var dif = Player.transform.position - transform.position;
                if (dif.magnitude > 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
                    velocity = (transform.position - previous) / Time.deltaTime;
                    previous = transform.position;
                }
                else
                {
                    velocity = Vector2.zero;
                }
                //Debug.Log("Looking at player");
                }
                    
            }
        
    }

    void AttackPlayer()
    {
        if(Time.time > nextFire)
        {
            if (attackAnimation) { animator.SetBool("Attacking", true); }
            soundLibrary.PlayEnemyAttack(enemyIndex);
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void StopAttackAnimation()
    {
        animator.SetBool("Attacking", false);
    }
    void WaitForPlayer()
    {
        waitForPlayer = false;
    }
}




