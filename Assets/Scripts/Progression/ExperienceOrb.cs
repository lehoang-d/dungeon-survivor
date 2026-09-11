using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    [SerializeField] private int experienceAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        
        ExperienceSystem experienceSystem = FindFirstObjectByType<ExperienceSystem>();

        if(experienceSystem == null)
            return;

        experienceSystem.AddExperience(experienceAmount);

        Collect();
    }

    private void Collect()
    {
        

        Destroy(gameObject);
    }
}
