using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 20f;

    private float currentHealth;

    private bool isDead;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth,0f);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        
        isDead = true;
        Destroy(gameObject);
    }
}
