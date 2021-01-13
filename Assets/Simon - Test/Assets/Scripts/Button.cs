using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    BetweenBattle betweenBattle;
    ShowMenuScreen showMenuScreen;
    GameSession gameSession;

    void Start()
    {
        betweenBattle = FindObjectOfType<BetweenBattle>();
        showMenuScreen = FindObjectOfType<ShowMenuScreen>();
        gameSession = GameSession.Instance;
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

    public void QuitGame()
    {
        showMenuScreen.CloseMenu();
        gameSession.OpenCanvas();
    }
}
