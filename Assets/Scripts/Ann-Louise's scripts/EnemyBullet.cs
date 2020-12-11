using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;

    float moveSpeed = 10f;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    PlayerController target;
    Vector2 moveDirection;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>();
        int currentSprite = Random.Range(0, sprites.Count - 1);
        spriteRenderer.sprite = sprites[currentSprite];
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);           
        }
    }
}
