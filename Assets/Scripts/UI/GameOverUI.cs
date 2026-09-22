using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnEnable()
    {
        if (gameManager != null)
        {
            gameManager.GameStateChanged+= OnGameStateChanged;
        }
    }

    private void OnDisable()
    {
        if(gameManager !=null)
        {
            gameManager.GameStateChanged -= OnGameStateChanged;
        }
    }

    private void OnGameStateChanged(GameState state)
    {
        gameOverPanel.SetActive(state == GameState.GameOver);
    }
}
