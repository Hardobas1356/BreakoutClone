using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        GameWaitingToStart,
        GamePlaying,
        GameOver
    }

    private State state;

    private void Start()
    {
        state = State.GameWaitingToStart;
    }
}
