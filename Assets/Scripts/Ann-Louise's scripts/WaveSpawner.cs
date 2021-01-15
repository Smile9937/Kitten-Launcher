using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
   public enum SpawnState { SPAWNING, WAITING, COUNTING};
    
    [System.Serializable]
   public class Wave
    {
        public string name;
        public Transform[] enemies;
        //Transform enemy;
        public int count;
        public float rate;
    }

    [SerializeField] GameObject portal;

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints; 

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    [SerializeField]
    private float searchCountdown = 1f;

    public bool canSpawn = false;
    public bool stopSpawning = false;

    private SpawnState state = SpawnState.COUNTING;
    PlayerController player;
    BetweenBattle betweenBattle;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn point referenced.");
        }

        waveCountdown = timeBetweenWaves;

    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            //Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        
        //Check if spawning
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING && canSpawn && !stopSpawning)
            {
                //start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            //Game state complete. Now what? Fanfare? Next level?
            //nextWave = 0;
            Debug.Log("All waves complete! Looping...");

            player.GetClosestRoom().spawnerInRoom = false;
            player.GetClosestRoom().roomCleared = true;
            player.GetClosestRoom().activeSpawners--;
            canSpawn = false;
            stopSpawning = true;
            if(player.GetClosestRoom().enemies <= 0)
            {
                betweenBattle.OpenPowerupScreen();
            }
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        // Spawn

        for(int i = 0; i < _wave.count; i++)
        {
            var enemyIndex = Random.Range(0, _wave.enemies.Length);
            SpawnEnemy(_wave.enemies[enemyIndex]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        // Spawn enemy
        Transform _spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(portal, _spawnPoint.position, _spawnPoint.rotation);
        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
    }
}
