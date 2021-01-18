using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    // Weapons

    [EventRef]
    string baseballGunSFX = "event:/SFX/Weapons/BaseBallGun_mixdown";

    [EventRef]
    string kittenLauncherSFX = "event:/SFX/Weapons/KittenLauncher";

    [EventRef]
    string piranhaGunSFX = "event:/SFX/Weapons/PiranhaGun";

    //Weapon Hit Effect
    [EventRef]
    string kittenParticleSFX = "event:/SFX/Weapons/Catfight";

    [EventRef]
    string piranhaParticleSFX = "event:/SFX/Weapons/PiranhaEffect";

    //The Living Health Heart

    [EventRef]
    string healthScreamingNoSFX = "event:/SFX/Health/HealthNO"; // To trigger when caught

    [EventRef]
    string healthScreamingSFX = "event:/SFX/Health/HealthSCREAM"; // To trigger when being chased

    // Enemy - Clown

    [EventRef]
    string clownAttackSFX = "event:/SFX/Enemies/Clown/ClownAttackRandom";

   

    // Enemy - Poshicorn boss

    [EventRef]
    string poshicornAttackSpeachSFX = "event:/SFX/Enemies/Poshicorn/PoshicornALLTRACKSRANDOM"; // To trigger when fighting, 1 instance of speech randomized.

    [EventRef]
    string poshicornAttackTeacupSFX = "event:/SFX/Enemies/Poshicorn/TeacupShot"; // To trigger when fighting, tea cup/projectile rattle.

    // Enemy - Devilcorn boss

    [EventRef]
    string devilcornWingflapSFX = "event:/SFX/Enemies/Devilcorn/DevilcornWINGFLAP"; // To trigger when moving

    [EventRef]
    string devilcornRandomSpeechSFX = "event:/SFX/Enemies/Devilcorn/DevilcornAttackRANDOMS"; // To trigger when fighting, speech

    [EventRef]
    string devilcornRandomAttackSFX = "event:/SFX/Enemies/Devilcorn/DevilcornAttackWeaponRANDOM"; // To trigger when fighting, weapon attack sounds

    // Enemy Uniblob

    [EventRef]
    string uniblobNeighSFX = "event:/SFX/Enemies/Uniblob/UniblobNEIGH";  // To trigger on death

    [EventRef]
    string uniblobRainbowFart = "event:/SFX/Enemies/Uniblob/Rainbowfart";  // To trigger when fighting

    // Enemy Snotblob

    [EventRef]
    string snotblobAttackSFX = "event:/SFX/Enemies/SnotblobATTACK";

    // Game Over SFX

    [EventRef]
    string gameOverSFX = "event:/SFX/GameOver";

    // Player getting hit, wet bloody slurpy

    [EventRef]
    string playerHitSFX = "event:/SFX/PlayerHit";

    // MUSIC

    [EventRef]
    string bossMusic = "event:/SFX/Music/BossMusic";  // Boss music, to trigger when fighting devilcorn and poshicorn

    [EventRef]
    string fightMusic = "event:/SFX/Music/FightMusic";  // Fight music, to trigger at start of the game, loops until boss music

    [EventRef]
    string menuMusic = "event:/SFX/Enemies/MenuMusic";  // Menu music, to plat during the start menu
    
    [EventRef]
    string fanfare = "event:/SFX/Music/Fanfare"; // Fanfare/level win sound

    //Menu

    [EventRef]
    string menuClick = "event:/SFX/Music/MenuClickGun";  // Menu/button click sounds. 


    private FMOD.Studio.EventInstance musicInstance;

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

    private void Start()
    {
        PlayMenuMusic();
    }

    //Weapon sounds
    public void PlayWeaponSound(int weaponSoundIndex)
    {
        switch (weaponSoundIndex)
        {
            case 0: //BaseballGun
                FMODUnity.RuntimeManager.PlayOneShot(baseballGunSFX, transform.position);
                break;
            case 1: //KittenLauncher
                FMODUnity.RuntimeManager.PlayOneShot(kittenLauncherSFX, transform.position);
                break;
            case 2: //PiranhaGun
                FMODUnity.RuntimeManager.PlayOneShot(piranhaGunSFX, transform.position);
                break;
        }
    }

    //Projectile hit
    public void PlayProjectileHit(int projectileSoundIndex)
    {
        switch (projectileSoundIndex)
        {
            case 1: //KittenLauncher
                FMODUnity.RuntimeManager.PlayOneShot(kittenParticleSFX, transform.position);
                break;
            case 2: //PiranhaGun
                FMODUnity.RuntimeManager.PlayOneShot(piranhaParticleSFX, transform.position);
                break;
        }
    }

    //Enemy Attack
    public void PlayEnemyAttack(int enemyAttackSoundIndex)
    {
        switch (enemyAttackSoundIndex)
        {
            case 0: //Clown
                FMODUnity.RuntimeManager.PlayOneShot(clownAttackSFX, transform.position);
                break;
            case 1: // Uniblob
                FMODUnity.RuntimeManager.PlayOneShot(uniblobRainbowFart, transform.position);
                break;
            case 2: // Blob
                FMODUnity.RuntimeManager.PlayOneShot(snotblobAttackSFX, transform.position);
                break;
        }
    }

    public void PlayBossAttack(int bossAttackSoundIndex)
    {
        switch (bossAttackSoundIndex)
        {

            case 0: //Poshicorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(poshicornAttackTeacupSFX, transform.position);
                break;
            case 1: // Devilcorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(devilcornRandomAttackSFX, transform.position);
                break;
        }
    }

    public void PlayBossAttackSpeech(int bossAttackSoundIndex)
    {
        switch (bossAttackSoundIndex)
        {

            case 0: //Poshicorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(poshicornAttackSpeachSFX, transform.position);
                break;
            case 1: // Devilcorn Boss
                FMODUnity.RuntimeManager.PlayOneShot(devilcornRandomSpeechSFX, transform.position);
                break;
        }
    }

    public void HealthHeartNoSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(healthScreamingNoSFX, transform.position);
    }

    public void HealthHeartScreamSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(healthScreamingSFX, transform.position);
    }

    public void BossDevilcornWingflapSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(devilcornWingflapSFX, transform.position);
    }

    public void UniblobNeighSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(uniblobNeighSFX, transform.position);
    }

    public void GameOverSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(gameOverSFX, transform.position);
    }

    public void PlayerHitSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(playerHitSFX, transform.position);
    }

    public void PlayBossMusic()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        musicInstance = RuntimeManager.CreateInstance(bossMusic);
        musicInstance.start();

        //musicInstance = FMODUnity.RuntimeManager.PlayOneShot(bossMusic, transform.position);
        
    }

    public void PlayFightMusic()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        musicInstance = RuntimeManager.CreateInstance(bossMusic);
        musicInstance.start();

        //FMODUnity.RuntimeManager.PlayOneShot(fightMusic, transform.position);
    }

    /*public void PlayMenuMusic()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        musicInstance = RuntimeManager.CreateInstance(bossMusic);
        musicInstance.start();
       
        //FMODUnity.RuntimeManager.PlayOneShot(menuMusic, transform.position);
    }*/

    public void PlayMenuMusic()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        musicInstance = RuntimeManager.CreateInstance(fanfare);
        musicInstance.start();
        
        //FMODUnity.RuntimeManager.PlayOneShot(fanfare, transform.position);
    }

    public void PlayButtonClick()
    {
        if (this != null) { RuntimeManager.PlayOneShot(menuClick, transform.position); }
    }


    public void StopMusic()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
