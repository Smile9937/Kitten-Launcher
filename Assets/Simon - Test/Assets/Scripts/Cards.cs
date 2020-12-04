using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card")]
public class Cards : ScriptableObject
{
    [Header("Text and image")]
    public string roomText;
    public string activatedText;
    public Sprite cardSprite;

    [Header("Effects")]
    public int moveSpeedBonus = 1;
}
