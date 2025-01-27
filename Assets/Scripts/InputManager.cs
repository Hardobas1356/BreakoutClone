using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private Actions inputActions;

    private void Awake()
    {
        Instance = this;
        inputActions = new Actions();
        inputActions.Enable();
    }

    private void OnDestroy()
    {
        inputActions.Disable(); 
    }

    public Vector2 getMovementVectorNormalized()
    {
        Vector2 inputVector = new Vector2(0f, 0f);

        inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }

    private void Pause()
    {
        
    }
}
