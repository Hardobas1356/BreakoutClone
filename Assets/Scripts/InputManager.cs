using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Vector2 getMovementVectorNormalized()
    {
        Vector2 inputVector = new Vector2(0f, 0f);

        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1f;
        }
        if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1f;
        }

        return inputVector.normalized;
    }
}
