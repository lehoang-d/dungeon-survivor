using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] private float baseMoveSpeed = 5f;
    [SerializeField] private float baseAttackSpeed = 1f;

    [Header("Modifiers")]
    [SerializeField] private float moveSpeedMultiplier = 1f;
    [SerializeField] private float attackSpeedMultiplier = 1f;

    [SerializeField] private float baseAttackDamage = 10f;
    [SerializeField] private float baseAttackRange = 2f;

    public float AttackDamage => baseAttackDamage;
    public float AttackRange => baseAttackRange;

    public float MoveSpeed => baseMoveSpeed * moveSpeedMultiplier;
    public float AttackSpeed => baseAttackSpeed * attackSpeedMultiplier;

    public void AddMoveSpeedMultiplier(float amount)
    {
        moveSpeedMultiplier += amount;
    }
    public void AddAttackSpeedMultiplier(float amount)
    {
        attackSpeedMultiplier += amount;
    }
}
