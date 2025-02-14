using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    public EventHandler OnObjectEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnObjectEnter?.Invoke(collision,EventArgs.Empty);
    }
}
