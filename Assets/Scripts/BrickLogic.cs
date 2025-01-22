using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    [SerializeField] private BrickSO startingBrickSO;
    private BrickSO currentBrickSO;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentBrickSO = startingBrickSO;
        spriteRenderer.color = currentBrickSO.color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentBrickSO.precedingBrickSO == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            currentBrickSO = currentBrickSO.precedingBrickSO;
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        spriteRenderer.color = currentBrickSO.color;
    }
}
