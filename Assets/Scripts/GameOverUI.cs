using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnStateChanged += GameOnStateChanged;

        Disable();
    }

    private void GameOnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
            Enable();
    }

    private void Enable()
    {
        this.gameObject.SetActive(true);
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
