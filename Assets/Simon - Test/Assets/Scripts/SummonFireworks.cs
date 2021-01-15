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
        int rand = Random.Range(0, 8);
        GameObject firework = Instantiate(fireworksParticle, new Vector2(transform.position.x, transform.position.y + rand), transform.rotation);
    }
}
