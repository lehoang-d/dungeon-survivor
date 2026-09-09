using UnityEngine;


[CreateAssetMenu(fileName = "WaveDifficulty", menuName = "Dungeon Survivor/Wave Difficulty")]
public class WaveDifficulty : ScriptableObject
{
    public int enemyCount = 5;
    public float enemyHealthMultiplier = 1f;
    public float enemyDamageMultiplier = 1f;
}
