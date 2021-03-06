﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] int destroyTimer = 7;
    [SerializeField] int minDistance = 6;
    [SerializeField] float healingAmount = 300;
    [SerializeField] Text healthText;
    [SerializeField] GameObject damageParticles;
    bool preventMultiSound = false;
    bool isPaused = false;
    PlayerController player;
    Rigidbody2D myRigidbody;
    GameSession gameSession;
    GameObject healthCanvas;
    SoundLibrary soundLibrary;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myRigidbody = GetComponent<Rigidbody2D>();
        gameSession = GameSession.Instance;
        healthCanvas = gameSession.transform.GetChild(0).gameObject;
        soundLibrary = SoundLibrary.Instance;
        Invoke("DestroyTimer", destroyTimer);
    }
    void Update()
    {
        if(!isPaused)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
            {

                if (!preventMultiSound) {
                    preventMultiSound = true;
                    soundLibrary.HealthHeartScreamSFX();
                    Invoke("PreventMultiSoundCooldown", 2f);
                }
                Vector3 dir = (transform.position - player.transform.position).normalized * moveSpeed;
                myRigidbody.velocity = dir;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("RoomExit"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (damageParticles != null) { Instantiate(damageParticles, transform.position, Quaternion.identity); }
            gameSession.IncreasePlayerHealth(healingAmount);
            Text healthTextInstance = Instantiate(healthText, player.transform.position, transform.rotation);
            healthTextInstance.transform.SetParent(healthCanvas.transform, false);

            RectTransform rectTransform = healthTextInstance.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(player.transform.position.x * 30, player.transform.position.y * 30);

            Text text = healthText.GetComponent<Text>();

            text.text = healingAmount.ToString();
            soundLibrary.HealthHeartNoSFX();
            Destroy(gameObject);
        }
    }

    public void DestroyTimer()
    {

        if (isPaused == false)
        {
            DestroyObject();
        }
        else
        {
            StartCoroutine(AsyncPrepareForPlay());
        }
    }
    IEnumerator AsyncPrepareForPlay()
    {
        yield return !isPaused;
        DestroyTimer();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void PreventMultiSoundCooldown()
    {
        preventMultiSound = false;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }
}
