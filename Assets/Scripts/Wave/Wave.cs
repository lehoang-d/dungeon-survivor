using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;


    [SerializeField] private float spawnRadius = 8f;

    [SerializeField] private float waveDuration = 5f;

    [SerializeField] private WaveDifficulty[] difficulties;
    

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

        int index = currentWave -1;

        if (index >= difficulties.Length)
            return;

        WaveDifficulty difficulty = difficulties[index];

        for (int i =0; i< difficulty.enemyCount; i++)
        {
            Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;

            enemySpawner.Spawn(spawnPosition,difficulty);
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
