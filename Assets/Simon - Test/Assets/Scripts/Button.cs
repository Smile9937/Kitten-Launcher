using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    BetweenBattle betweenBattle;
    ShowMenuScreen showMenuScreen;
    GameSession gameSession;
    SceneTransition sceneTransition;
    SoundLibrary soundLibrary;

    void Start()
    {
        betweenBattle = FindObjectOfType<BetweenBattle>();
        showMenuScreen = FindObjectOfType<ShowMenuScreen>();
        gameSession = GameSession.Instance;
        sceneTransition = FindObjectOfType<SceneTransition>();
        soundLibrary = FindObjectOfType<SoundLibrary>();
    }

    public void StartGame()
    {
        soundLibrary.PlayButtonClick();
        sceneTransition.GotoCurrentLevel();
    }

    public void Level1()
    {
        soundLibrary.PlayButtonClick();
        sceneTransition.GotoLevel(1);
    }

    public void RestartGame()
    {
        soundLibrary.PlayButtonClick();
        gameSession.level = 0;
        sceneTransition.GotoMenu();
    }

    public void QuitMenu()
    {
        soundLibrary.PlayButtonClick();
        betweenBattle.CloseDiscardCard();
        gameSession.OpenCanvas();
    }

    public void CloseMenu()
    {
        soundLibrary.PlayButtonClick();
        showMenuScreen.CloseMenu();
        gameSession.OpenCanvas();
    }

    public void MainMenu()
    {
        soundLibrary.PlayButtonClick();
        sceneTransition.GotoMenu();
    }

    public void QuitGame()
    {
        soundLibrary.PlayButtonClick();
        showMenuScreen.CloseMenu();
        gameSession.OpenCanvas();
    }

    public void CloseGame()
    {
        soundLibrary.PlayButtonClick();
        Application.Quit();
    }

    public void OpenCredits()
    {
        soundLibrary.PlayButtonClick();
        sceneTransition.GotoCredits();
    }
}
