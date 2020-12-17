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
    //Not finished
    public void PlayProjectileHit(int projectileSoundIndex)
    {
        switch (projectileSoundIndex)
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

    //Enemy Attack
    public void PlayEnemyAttack(int enemyAttackSoundIndex)
    {
        switch (enemyAttackSoundIndex)
        {
            case 0:
                FMODUnity.RuntimeManager.PlayOneShot(baseballGunSFX, GetComponent<Transform>().position);
                break;
            case 1:
                FMODUnity.RuntimeManager.PlayOneShot(kittenLauncherSFX, GetComponent<Transform>().position);
                break;
            case 2:
                FMODUnity.RuntimeManager.PlayOneShot(piranhaGunSFX, GetComponent<Transform>().position);
                break;
        }
    }

    public void HealthHeartNoSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(healthScreamingNoSFX);

        FMODUnity.RuntimeManager.PlayOneShot(healthScreamingNoSFX, GetComponent<Transform>().position);
    }

    public void HealthHeartScreamSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(healthScreamingSFX);

        FMODUnity.RuntimeManager.PlayOneShot(healthScreamingSFX, GetComponent<Transform>().position);
    }

    public void EnemyClownSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(clownAttackSFX);

        FMODUnity.RuntimeManager.PlayOneShot(clownAttackSFX, GetComponent<Transform>().position);
    }

    public void BossPoshicornSpeechSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(poshicornAttackSpeachSFX);

        FMODUnity.RuntimeManager.PlayOneShot(poshicornAttackSpeachSFX, GetComponent<Transform>().position);
    }

    public void BossPoshicornTeacupAttackSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(poshicornAttackTeacupSFX);

        FMODUnity.RuntimeManager.PlayOneShot(poshicornAttackTeacupSFX, GetComponent<Transform>().position);
    }

    public void BossDevilcornWingflapSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(devilcornWingflapSFX);

        FMODUnity.RuntimeManager.PlayOneShot(devilcornWingflapSFX, GetComponent<Transform>().position);
    }

    public void BossDevilcornRandomSpeechSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(devilcornRandomSpeechSFX);

        FMODUnity.RuntimeManager.PlayOneShot(devilcornRandomSpeechSFX, GetComponent<Transform>().position);
    }

    public void BossDevilcornWeaponSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(devilcornRandomAttackSFX);

        FMODUnity.RuntimeManager.PlayOneShot(devilcornRandomAttackSFX, GetComponent<Transform>().position);
    }

    public void UniblobNeighSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(uniblobNeighSFX);

        FMODUnity.RuntimeManager.PlayOneShot(uniblobNeighSFX, GetComponent<Transform>().position);
    }

    public void UniblobFartSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(uniblobRainbowFart);

        FMODUnity.RuntimeManager.PlayOneShot(uniblobRainbowFart, GetComponent<Transform>().position);
    }

    public void SnotblobAttackSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(snotblobAttackSFX);

        FMODUnity.RuntimeManager.PlayOneShot(snotblobAttackSFX, GetComponent<Transform>().position);
    }

    public void GameOverSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(gameOverSFX);

        FMODUnity.RuntimeManager.PlayOneShot(gameOverSFX, GetComponent<Transform>().position);
    }

    public void PlayerHitSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(playerHitSFX);

        FMODUnity.RuntimeManager.PlayOneShot(playerHitSFX, GetComponent<Transform>().position);
    }

}
