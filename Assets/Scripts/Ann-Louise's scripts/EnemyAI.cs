using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{ 
    private Transform player;
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
    bool isPaused = false;

    private Rigidbody2D rb;

    Animator animator;
    Enemy enemy;
    SoundLibrary soundLibrary;
    GameSession gameSession;

    void Start()
    {
        gameSession = GameSession.Instance;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Checking when it's time to fire/attack
        nextFire = Time.time;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
        soundLibrary = SoundLibrary.Instance;
        Invoke("WaitForPlayer", 0.5f);
    }

    void Update()
    {
        if (!isPaused)
        {
            if (player != null && !waitForPlayer)
            {
                if (Vector3.Distance(transform.position, player.position) <= MaxDist)
        
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

    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            if (player != null && !waitForPlayer)
            {
                if (moving)
                {
                    ChasePlayer();
                }
            }
        }
    }

    private void ChasePlayer()
    {
            if (player != null)
            {
                if (Vector3.Distance(transform.position, player.position) >= MinDist)
                {
                    var dif = player.transform.position - transform.position;
                    if (dif.magnitude > 1)
                    {

                        rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, MoveSpeed * Time.deltaTime));
                    
                        velocity = (transform.position - previous) / Time.deltaTime;
                        previous = transform.position;
                    }
                    else
                    {
                        velocity = Vector2.zero;
                    }
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

    public void TogglePause()
    {
        isPaused = !isPaused;
    }
}




