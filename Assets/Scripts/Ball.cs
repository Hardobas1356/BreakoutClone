using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;

    private Rigidbody2D rb;
    private Vector2 initialPosition = new Vector2(0f,-3.25f);
    private Vector2 direction = Vector2.up;
    private float speed = 700f;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * direction;
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 newDirection = Vector2.Reflect(rb.position, collision.gameObject.transform.position);
        direction = newDirection.normalized;
    }

    public void ResetBall()
    {
        rb.position = initialPosition;
        direction = Vector2.up;
    }
}
