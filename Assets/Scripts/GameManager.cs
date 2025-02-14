using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Life { get; private set; } = 3;
    public EventHandler LifeLowered;
    public EventHandler OnStateChanged;
    public enum State
    {
        GameWaitingToStart,
        GamePlaying,
        GameOver
    }

    private bool isGamePaused = false;
    private State state;
    private float countdownToStart = 3f;

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Ball.Instance.OnBallResetTrigger += BallWasReset;
        InputManager.Instance.PauseButtonPressed += PauseGameOccured;
        state = State.GameWaitingToStart;
    }

    private void PauseGameOccured(object sender, EventArgs e)
    {
        PauseGame();
    }

    private void Update()
    {
        switch (state)
        {
            case State.GameWaitingToStart:
                countdownToStart -= Time.deltaTime;

                if (countdownToStart <= 0)
                    state = State.GamePlaying;
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.GamePlaying:
                OnStateChanged?.Invoke(this, EventArgs.Empty);

                if (Life <= 0)
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            default:
                break;
        }
    }
    private void BallWasReset(object sender, EventArgs e)
    {
        Life--;
        LifeLowered?.Invoke(this, null);

        if (Life == 0)
        {
            state = State.GameOver;
        }
    }

    private void PauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
