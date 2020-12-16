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
    string kittenParticleSFX = "event:/SFX/Weapons/Catfight";

    [FMODUnity.EventRef]
    string piranhaGunSFX = "event:/SFX/Weapons/PiranhaGun";

    //The Living Health Heart

    [FMODUnity.EventRef]
    string healthScreamingNoSFX = "event:/SFX/Health/HealthNO";

    [FMODUnity.EventRef]
    string healthScreamingSFX = "event:/SFX/Health/HealthSCREAM";

    // Enemy - Clown

    [FMODUnity.EventRef]
    string clownAttackSFX = "event:/SFX/Enemies/Clown/ClownAttackRandom";

   

    // Enemy - Poshicorn boss

    [FMODUnity.EventRef]
    string poshicornAttackSpeachSFX = "event:/SFX/Enemies/Poshicorn/PoshicornALLTRACKSRANDOM";

    [FMODUnity.EventRef]
    string poshicornAttackTeacupSFX = "event:/SFX/Enemies/Poshicorn/TeacupShot";

    // Enemy - Devilcorn boss

    [FMODUnity.EventRef]
    string devilcornWingflapSFX = "event:/SFX/Enemies/Devilcorn/DevilcornWINGFLAP";

    [FMODUnity.EventRef]
    string devilcornRandomSpeechSFX = "event:/SFX/Enemies/Devilcorn/DevilcornAttackRANDOMS";

    [FMODUnity.EventRef]
    string devilcornRandomAttackSFX = "event:/SFX/Enemies/Devilcorn/DevilcornAttackWeaponRANDOM";

    // Enemy Uniblob

    [FMODUnity.EventRef]
    string uniblobNeighSFX = "event:/SFX/Enemies/Uniblob/UniblobNEIGH";

    [FMODUnity.EventRef]
    string uniblobRainbowFart = "event:/SFX/Enemies/Uniblob/Rainbowfart";

    // Enemy Snotblob

    [FMODUnity.EventRef]
    string snotblobAttackSFX = "event:/SFX/Enemies/SnotblobATTACK";

    // Game Over SFX

    [FMODUnity.EventRef]
    string gameOverSFX = "event:/SFX/GameOver";

    // Player getting hit, wet bloody slurpy

    [FMODUnity.EventRef]
    string playerHitSFX = "event:/SFX/PlayerHit";

   
    public void BaseballGunSFX()
    {
        
        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(baseballGunSFX);
       
        FMODUnity.RuntimeManager.PlayOneShot(baseballGunSFX, GetComponent<Transform>().position);
    }

    public void KittenLauncherSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(kittenLauncherSFX);

        FMODUnity.RuntimeManager.PlayOneShot(kittenLauncherSFX, GetComponent<Transform>().position);
    }

    public void PiranhaGunSFX()
    {

        FMOD.Studio.EventInstance musicEv = FMODUnity.RuntimeManager.CreateInstance(piranhaGunSFX);

        FMODUnity.RuntimeManager.PlayOneShot(piranhaGunSFX, GetComponent<Transform>().position);
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
