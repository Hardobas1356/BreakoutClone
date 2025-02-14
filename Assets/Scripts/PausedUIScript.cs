using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedUIScript : MonoBehaviour
{
    private bool isEnabled = false;
    private void Start()
    {
        InputManager.Instance.PauseButtonPressed += PausePerformed;
        this.gameObject.SetActive(false);
    }

    private void PausePerformed(object sender, EventArgs e)
    {
        if (isEnabled) Disable();
        else Enable();

        isEnabled = !isEnabled;
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
