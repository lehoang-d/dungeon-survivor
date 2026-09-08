using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;

    private float currentHealth;

    private bool isDead;

    private GameManager gameManager;

    private void Awake()
    {
        currentHealth = maxHealth;
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        currentHealth = currentHealth - damage;
        currentHealth = Mathf.Max(currentHealth, 0f); 

        if (currentHealth <=0f)
        {
            Die();
        }
    }
   

    private void Die()
    {
        isDead = true;
        gameManager.GameOver();
    }
}
