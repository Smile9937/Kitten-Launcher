using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyGameObject", 0.5f);
    }
    void Update()
    {
        transform.Translate(0.1f, 0.7f, 0);
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
