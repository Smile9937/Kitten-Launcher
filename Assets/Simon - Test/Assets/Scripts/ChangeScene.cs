using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    SceneTransition sceneTransition;
    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            sceneTransition.GotoNextLevel();
        }
    }
}
