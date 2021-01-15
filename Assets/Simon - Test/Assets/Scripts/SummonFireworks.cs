using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonFireworks : MonoBehaviour
{
    [SerializeField] GameObject fireworksParticle;
    void Start()
    {
        int spawnDelay = Random.Range(0, 1);
        Invoke("SpawnDelay", spawnDelay);


    }
    void SpawnDelay()
    {
        GameObject firework = Instantiate(fireworksParticle, transform.position, transform.rotation);
    }
}
