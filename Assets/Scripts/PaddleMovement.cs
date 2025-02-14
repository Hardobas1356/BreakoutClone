using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private GameObject paddle;
    private float movementSpeed = 15f;
    RaycastHit2D hit;

    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        Vector2 input = InputManager.Instance.getMovementVectorNormalized();

        float paddleLenght = paddle.transform.localScale.x / 2;
        LayerMask wallLayer = LayerMask.GetMask("Walls");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, input, paddleLenght, wallLayer);

        if (hit.collider == null)
        {
            transform.position += new Vector3((input * Time.deltaTime * movementSpeed).x, 0f, 0f);
        }
        else
        {
        }
    }
}
