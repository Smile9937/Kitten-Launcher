using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    // Weapons

    [FMODUnity.EventRef]
    string baseballGunSFX = "event:/SFX/Weapons/BaseBallGun_mixdown";

    [FMODUnity.EventRef]
    string kittenLauncherSFX = "event:/SFX/Weapons/KittenLauncher";

    [FMODUnity.EventRef]
    string piranhaGunSFX = "event:/SFX/Weapons/PiranhaGun";

    //Weapon Hit Effect
    [FMODUnity.EventRef]
    string kittenParticleSFX = "event:/SFX/Weapons/Catfight";

    [FMODUnity.EventRef]
    string piranhaParticleSFX = "event:/SFX/Weapons/PiranhaEffect";

    //The Living Health Heart

    [FMODUnity.EventRef]
    string healthScreamingNoSFX = "event:/SFX/Health/HealthNO"; // To trigger when caught

    [FMODUnity.EventRef]
    string healthScreamingSFX = "event:/SFX/Health/HealthSCREAM"; // To trigger when being chased

    // Enemy - Clown

    [FMODUnity.EventRef]
    string clownAttackSFX = "event:/SFX/Enemies/Clown/ClownAttackRandom";

   

    // Enemy - Poshicorn boss

    [FMODUnity.EventRef]
    string poshicornAttackSpeachSFX = "event:/SFX/Enemies/Poshicorn/PoshicornALLTRACKSRANDOM"; // To trigger when fighting, 1 instance of speech randomized.

    [FMODUnity.EventRef]
    string poshicornAttackTeacupSFX = "event:/SFX/Enemies/Poshicorn/TeacupShot"; // To trigger when fighting, tea cup/projectile rattle.

    // Enemy - Devilcorn boss

    [FMODUnity.EventRef]
    string devilcornWingflapSFX = "event:/SFX/Enemies/Devilcorn/DevilcornWINGFLAP"; // To trigger when moving

    [FMODUnity.EventRef]
    string devilcornRandomSpeechSFX = "event:/SFX/Enemies/Devilcorn/DevilcornAttackRANDOMS"; // To trigger when fighting, speech

    [FMODUnity.EventRef]
    string devilcornRandomAttackSFX = "event:/SFX/Enemies/Devilcorn/DevilcornAttackWeaponRANDOM"; // To trigger when fighting, weapon attack sounds

    // Enemy Uniblob

    [FMODUnity.EventRef]
    string uniblobNeighSFX = "event:/SFX/Enemies/Uniblob/UniblobNEIGH";  // To trigger on death

    [FMODUnity.EventRef]
    string uniblobRainbowFart = "event:/SFX/Enemies/Uniblob/Rainbowfart";  // To trigger when fighting

    // Enemy Snotblob

    [FMODUnity.EventRef]
    string snotblobAttackSFX = "event:/SFX/Enemies/SnotblobATTACK";

    // Game Over SFX

    [FMODUnity.EventRef]
    string gameOverSFX = "event:/SFX/GameOver";

    // Player getting hit, wet bloody slurpy

    [FMODUnity.EventRef]
    string playerHitSFX = "event:/SFX/PlayerHit";

    // MUSIC

    [FMODUnity.EventRef]
    string bossMusic = "event:/SFX/Music/BossMusic";  // Boss music, to trigger when fighting devilcorn and poshicorn

    [FMODUnity.EventRef]
    string FightMusic = "event:/SFX/Music/FightMusic";  // Fight music, to trigger at start of the game, loops until boss music

    [FMODUnity.EventRef]
    string menuMusic = "event:/SFX/Enemies/MenuMusic";  // Menu music, to plat during the start menu
    
    [FMODUnity.EventRef]
    string fanfare = "event:/SFX/Music/Fanfare"; // Fanfare/level win sound

    [FMODUnity.EventRef]
    string menuClick = "event:/SFX/Music/MenuClickGun";  // Menu/button click sounds. 

    

    public static SoundLibrary Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    //Weapon sounds
    public void PlayWeaponSound(int weaponSoundIndex)
    {
        switch (weaponSoundIndex)
        {
            case 0: //BaseballGun
                FMODUnity.RuntimeManager.PlayOneShot(baseballGunSFX, GetComponent<Transform>().position);
                break;
            case 1: //KittenLauncher
                FMODUnity.RuntimeManager.PlayOneShot(kittenLauncherSFX, GetComponent<Transform>().position);
                break;
            case 2: //PiranhaGun
                FMODUnity.RuntimeManager.PlayOneShot(piranhaGunSFX, GetComponent<Transform>().position);
                break;
        }
    }

    //Projectile hit
    public void PlayProjectileHit(int projectileSoundIndex)
    {
        switch (projectileSoundIndex)
        {
            case 1: //KittenLauncher
                FMODUnity.RuntimeManager.PlayOneShot(kittenParticleSFX, GetComponent<Transform>().position);
                break;
            case 2: //PiranhaGun
                FMODUnity.RuntimeManager.PlayOneShot(piranhaParticleSFX, GetComponent<Transform>().position);
                break;
        }
    }

    //Enemy Attack
    public void PlayEnemyAttack(int enemyAttackSoundIndex)
    {
        switch (enemyAttackSoundIndex)
        {
            case 0: //Clown
                FMODUnity.RuntimeManager.PlayOneShot(clownAttackSFX, GetComponent<Transform>().position);
                break;
            case 1: // Uniblob
                FMODUnity.RuntimeManager.PlayOneShot(uniblobRainbowFart, GetComponent<Transform>().position);
                break;
            case 2: // Blob
                FMODUnity.RuntimeManager.PlayOneShot(snotblobAttackSFX, GetComponent<Transform>().position);
                break;
        }
    }

    public void PlayBossAttack(int bossAttackSoundIndex)
    {
        switch (bossAttackSoundIndex)
        {

            case 0: //Poshicorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(poshicornAttackTeacupSFX, GetComponent<Transform>().position);
                break;
            case 1: // Devilcorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(devilcornRandomAttackSFX, GetComponent<Transform>().position);
                break;
        }
    }
    public void PlayBossAttackSpeech(int bossAttackSoundIndex)
    {
        switch (bossAttackSoundIndex)
        {

            case 0: //Poshicorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(poshicornAttackSpeachSFX, GetComponent<Transform>().position);
                break;
            case 1: // Devilcorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(devilcornRandomSpeechSFX, GetComponent<Transform>().position);
                break;
        }
    }

    public void HealthHeartNoSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(healthScreamingNoSFX, GetComponent<Transform>().position);
    }

    public void HealthHeartScreamSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(healthScreamingSFX, GetComponent<Transform>().position);
    }

    public void BossDevilcornWingflapSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(devilcornWingflapSFX, GetComponent<Transform>().position);
    }

    public void UniblobNeighSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(uniblobNeighSFX, GetComponent<Transform>().position);
    }

    public void GameOverSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(gameOverSFX, GetComponent<Transform>().position);
    }

    public void PlayerHitSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(playerHitSFX, GetComponent<Transform>().position);
    }

}
