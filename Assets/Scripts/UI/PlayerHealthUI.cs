using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Slider healthBar;

    private void OnEnable()
    {
        playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        OnHealthChanged(playerHealth.CurrentHealth,playerHealth.MaxHealth);
    }

    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        healthBar.value = currentHealth / maxHealth;
    }
}

