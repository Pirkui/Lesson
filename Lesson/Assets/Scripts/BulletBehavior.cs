using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;


    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        float _dir;
        
        if (PlayerController.Instance.sr.flipX == false)
        {
            _dir = 1;
        }
        else
        {
            _dir = -1;
        }
        rb.velocity = new Vector2(_dir * moveSpeed, 0);

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
}
