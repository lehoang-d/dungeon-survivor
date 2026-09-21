using UnityEngine;

public class HealthDebug : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private void OnEnable()
    {
        playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        Debug.Log($"Player HP: {currentHealth}/{maxHealth}");
    }
}
