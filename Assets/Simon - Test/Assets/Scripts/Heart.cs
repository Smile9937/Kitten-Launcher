using System.Collections;
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
    bool preventMultiSound = false;
    PlayerController player;
    Rigidbody2D myRigidbody;
    GameSession gameSession;
    GameObject healthCanvas;
    SoundLibrary soundLibrary;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myRigidbody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
        healthCanvas = gameSession.transform.GetChild(0).gameObject;
        soundLibrary = FindObjectOfType<SoundLibrary>();
        Invoke("DestroyTimer", destroyTimer);
    }
    void Update()
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
    void DestroyTimer()
    {
        Destroy(gameObject);
    }

    void PreventMultiSoundCooldown()
    {
        preventMultiSound = false;
    }
}
