using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyGameobject", 5f);
    }

    void DestroyGameobject()
    {
        Destroy(gameObject);
    }
}
