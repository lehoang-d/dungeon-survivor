using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isDead;

    private GameManager gameManager;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
    public bool IsDead => isDead;

    private void Awake()
    {
        currentHealth = maxHealth;
        gameManager = FindFirstObjectByType<GameManager>();
        HealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(DamageData damageData)
    {
        if (isDead)
            return;

        currentHealth = currentHealth - damageData.amount;
        currentHealth = Mathf.Max(currentHealth, 0f); 

        HealthChanged?.Invoke(currentHealth,maxHealth);

        if (currentHealth <=0f)
        {
            Die();
        }
    }
   

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;

        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.GameOver();
        }

        Debug.Log("Player died!");
    }

    public event Action<float, float> HealthChanged;
}
