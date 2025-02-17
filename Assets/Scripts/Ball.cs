using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    public EventHandler OnBallResetTrigger;

    private Rigidbody2D rb;
    private Vector2 initialPosition = new Vector2(0f,-1f);
    private float speed = 400f;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Invoke(nameof(LaunchBall),1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnBallResetTrigger?.Invoke(this,EventArgs.Empty);
        ResetBall();
    }

    private void LaunchBall()
    {
        Vector2 force = Vector2.zero;
        force.x = UnityEngine.Random.Range(-1f,1f);
        force.y = -1f;

        rb.AddForce(force.normalized*speed);
    }

    public void ResetBall()
    {
        rb.position = initialPosition;
        rb.velocity = Vector2.zero;

        Invoke(nameof(LaunchBall), 1);
    }
}
