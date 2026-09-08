using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public void Spawn(Vector2 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
