using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefab : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    PlayerController player;
    BetweenBattle betweenBattle;
    RoomManager roomManager;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        betweenBattle = FindObjectOfType<BetweenBattle>();
        roomManager = FindObjectOfType<RoomManager>();

        //Change image
        UnityEngine.UI.Image  currentSprite = gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
        currentSprite.sprite = weapon.currentWeaponSpr;
    }

    public void GivePlayerWeapon()
    {
        player.currentWeapon = weapon;
        betweenBattle.ClosePowerupScreen();
        player.GetClosestRoom().OpenDoors();

    }

    public void SelectWeapon()
    {

    }
}
