using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    GameSession gameSession;

    private void Start()
    {
        gameSession = GameSession.Instance;
    }
    public void GotoNextLevel()
    {
 
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void Restart()
    {
        Destroy(gameSession.gameObject);
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose Screen");
    }
}
