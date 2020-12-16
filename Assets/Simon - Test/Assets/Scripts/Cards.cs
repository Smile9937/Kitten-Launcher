using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card")]
public class Cards : ScriptableObject
{
    public int id;

    [Header("Text and image")]
    public string roomText;
    public string activatedText;
    public Sprite cardSprite;

    [Header("Passive Effects")]
    public float passiveAttackDamage = 0;
    public float passiveAttackSpeed = 0;

    [Header("Activated Effects")]
    public float attackDamage = 0;
    public float moveSpeed = 0;
    public float attackSpeed = 0;
}
