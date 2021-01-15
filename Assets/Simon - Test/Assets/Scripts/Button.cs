using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    BetweenBattle betweenBattle;
    ShowMenuScreen showMenuScreen;
    GameSession gameSession;
    SceneTransition sceneTransition;

    void Start()
    {
        betweenBattle = FindObjectOfType<BetweenBattle>();
        showMenuScreen = FindObjectOfType<ShowMenuScreen>();
        gameSession = GameSession.Instance;
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void StartGame()
    {
        sceneTransition.GotoCurrentLevel();
    }

    public void RestartGame()
    {
        gameSession.level = 0;
        sceneTransition.GotoMenu();
    }

    public void QuitMenu()
    {
        betweenBattle.CloseDiscardCard();
        gameSession.OpenCanvas();
    }

    public void CloseMenu()
    {
        showMenuScreen.CloseMenu();
        gameSession.OpenCanvas();
    }

    public void MainMenu()
    {
        sceneTransition.GotoMenu();
    }

    public void QuitGame()
    {
        showMenuScreen.CloseMenu();
        gameSession.OpenCanvas();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        sceneTransition.GotoCredits();
    }
}
