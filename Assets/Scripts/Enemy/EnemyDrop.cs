using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    
    [SerializeField] private GameObject experienceOrbPrefab;

    public void DropExperience()
    {
        if (experienceOrbPrefab == null)
            return;

        Instantiate(experienceOrbPrefab, transform.position,Quaternion.identity);
    }
}
