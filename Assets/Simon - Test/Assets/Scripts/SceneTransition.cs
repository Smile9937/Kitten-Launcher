using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    GameSession gameSession;
    SoundLibrary soundLibrary;

    private void Start()
    {
        gameSession = GameSession.Instance;
        soundLibrary = SoundLibrary.Instance;
    }
    public void GotoNextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void GotoCurrentLevel()
    {
        if(gameSession.level > 0)
        {
            gameSession.OpenCanvas();
            SceneManager.LoadScene(gameSession.level);
        } else
        {
            gameSession.OpenCanvas();
            SceneManager.LoadScene(1);
        }
    }

    public void GotoMenu()
    {
        gameSession.HideCanvas();
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Destroy(gameSession.gameObject);
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        gameSession.HideCanvas();
        soundLibrary.GameOverSFX();
        SceneManager.LoadScene("Lose Screen");
    }

    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GotoLevel(int level) {
        SceneManager.LoadScene(level);
    }
}
