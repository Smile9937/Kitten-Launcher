using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    BetweenBattle betweenBattle;

    void Start()
    {
        betweenBattle = FindObjectOfType<BetweenBattle>();
    }

    public void QuitMenu()
    {
        betweenBattle.CloseDiscardCard();
    }
}
