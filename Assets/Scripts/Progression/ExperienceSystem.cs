using UnityEngine;
using System;

public class ExperienceSystem : MonoBehaviour
{
    [SerializeField] private int currentExperience;

    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int requiredExperience = 100;

    [SerializeField] private float experienceGrowthRate = 1.2f;

    public int CurrentExperience => currentExperience;
    public int CurrentLevel => currentLevel;
    public int RequiredExperience => requiredExperience;

    public event Action<int> LevelUp;

    public void AddExperience(int amount)
    {
        if (amount <= 0)
            return;

        currentExperience = currentExperience + amount;

        CheckLevelUp();

        Debug.Log($"Current EXP: {currentExperience}");
    }

    private void CheckLevelUp()
    {
        while(currentExperience >= requiredExperience)
        {
            currentExperience = currentExperience - requiredExperience;
            currentLevel++;

            requiredExperience = Mathf.CeilToInt(requiredExperience*experienceGrowthRate);

            LevelUp?.Invoke(currentLevel);
            Debug.Log(
                $"Level Up! Level: {currentLevel} | " +
                $"Next EXP: {requiredExperience}"
            );
        }
    }
}
