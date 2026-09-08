using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private float spawnRadius = 8f;

    [SerializeField] private float waveDuration = 10f;

    private float waveTimer;

    private int currentWave;

    private void Awake()
    {
        currentWave = 0;
    }

    private void Start()
    {
        StartWave();
    }

    private void StartWave()
    {
        currentWave++;

        for (int i = 0; i< enemiesPerWave; i++)
        {
            Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;
            enemySpawner.Spawn(spawnPosition);
        }
    }

    private void Update()
    {
        waveTimer = waveTimer + Time.deltaTime;

        if (waveTimer >= waveDuration)
        {
            waveTimer = 0f;
            StartWave();
        }
    }

    
}
