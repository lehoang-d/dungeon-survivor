using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public void Spawn(Vector2 position, WaveDifficulty difficulty)
    {
        GameObject enemyObject = Instantiate(enemyPrefab, position, Quaternion.identity);

        EnemyHealth enemyHealth = enemyObject.GetComponent<EnemyHealth>();

        enemyHealth.SetHealthMultiplier(difficulty.enemyHealthMultiplier);

        EnemyContactDamage contactDamage = enemyObject.GetComponent<EnemyContactDamage>();
        contactDamage.SetDamageMultiplier(difficulty.enemyDamageMultiplier);
 

    }
}
