using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public EventHandler PauseButtonPressed;

    private Actions inputActions;

    private void Awake()
    {
        Instance = this;
        inputActions = new Actions();
        inputActions.Enable();

        inputActions.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        PauseButtonPressed?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        inputActions.Dispose(); 
    }

    public Vector2 getMovementVectorNormalized()
    {
        Vector2 inputVector = new Vector2(0f, 0f);

        inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }
}
