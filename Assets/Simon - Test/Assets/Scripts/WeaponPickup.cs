using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    SpriteRenderer spriteRenderer;
    GameSession gameSession;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = weapon.currentWeaponSpr;

        gameSession = GameSession.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameSession.currentPlayerWeapon = weapon;
            Destroy(gameObject);
        }
    }
}
