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
        soundLibrary.PlayFightMusic();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void GotoCurrentLevel()
    {
        soundLibrary.PlayFightMusic();
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
        soundLibrary.PlayMenuMusic();
        gameSession.HideCanvas();
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        soundLibrary.PlayMenuMusic();
        Destroy(gameSession.gameObject);
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        soundLibrary.StopMusic();
        gameSession.HideCanvas();
        soundLibrary.GameOverSFX();
        SceneManager.LoadScene("Lose Screen");
    }

    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GotoLevel(int level)
    {
        soundLibrary.PlayFightMusic();
        SceneManager.LoadScene(level);
    }
}
