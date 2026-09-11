using UnityEngine;

public class ExperienceSystemDebug : MonoBehaviour
{
    
    private ExperienceSystem experienceSystem;

    private void Start()
    {
        experienceSystem = FindFirstObjectByType<ExperienceSystem>();

        if(experienceSystem ==null)
            return;

        experienceSystem.LevelUp += OnLevelUp;
    }

    private void OnLevelUp(int level)
    {
        Debug.Log($"[DEBUG] LevelUp event received! Level = {level}");
    }

    private void OnDestroy()
    {
        if (experienceSystem !=null)
        {
            experienceSystem.LevelUp -=OnLevelUp;
        }
    }
}
