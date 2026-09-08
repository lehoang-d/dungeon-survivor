using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState {get; private set;}

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        CurrentState = GameState.Playing;
    }

    public void Pause()
    {
        if (CurrentState != GameState.Playing)
            return;
        
        CurrentState = GameState.Paused;
    }

    public void Resume()
    {
        if (CurrentState != GameState.Paused)
            return;

        CurrentState = GameState.Playing;
    }

    public void GameOver()
    {
        if (CurrentState == GameState.GameOver)
            return;

        CurrentState = GameState.GameOver;
    }

    public void Restart()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
