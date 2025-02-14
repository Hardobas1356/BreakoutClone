using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUiText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HealthText;

    private void Start()
    {
        GameManager.Instance.LifeLowered += GameManagerLifeLowered;
    }

    private void GameManagerLifeLowered(object sender, EventArgs e)
    {
        UpdateText(GameManager.Instance.Life.ToString());
    }

    private void UpdateText(string text)
    {
        HealthText.text = text;
    }
}
