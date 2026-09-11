using UnityEngine;

public class EnemyDebugKill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        EnemyHealth enemyHealth = GetComponent<EnemyHealth>();

        if(enemyHealth!=null)
        {
            enemyHealth.DebugKill();
        }
    }
}
