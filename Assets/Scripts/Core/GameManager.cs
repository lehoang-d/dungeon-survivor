using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState currentState;
    public GameState CurrentState => currentState;

    public event Action<GameState> GameStateChanged;

    private void Awake()
    {
        Initialize();
        GameStateChanged?.Invoke(currentState);
    }

    private void Initialize()
    {
        currentState = GameState.Playing;
    }

    public void Pause()
    {
        if (currentState != GameState.Playing)
            return;
        
        currentState = GameState.Paused;
        GameStateChanged?.Invoke(currentState);
    }

    public void Resume()
    {
        if (currentState != GameState.Paused)
            return;

        currentState = GameState.Playing;
        GameStateChanged?.Invoke(currentState);
    }

    public void GameOver()
    {
        if (currentState == GameState.GameOver)
            return;

        currentState = GameState.GameOver;
        GameStateChanged?.Invoke(currentState);
    }

    public void Restart()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
