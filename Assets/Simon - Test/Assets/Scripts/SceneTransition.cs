using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void GotoNextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose Screen");
    }
}
