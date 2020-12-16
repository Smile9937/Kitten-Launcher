using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    BetweenBattle betweenBattle;
    GameSession gameSesison;

    void Start()
    {
        betweenBattle = FindObjectOfType<BetweenBattle>();
        gameSesison = GameSession.Instance;
    }

    public void QuitMenu()
    {
        betweenBattle.CloseDiscardCard();
        gameSesison.OpenCanvas();
    }
}
