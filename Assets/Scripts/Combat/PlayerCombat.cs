using UnityEngine;
using System;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCombat : MonoBehaviour
{
    

    [SerializeField] private LayerMask enemyPlayer;

    public event Action Attacked;

    private PlayerStats playerStats;
    private float attackTimer;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    private void Start()
    {
        if (attackRangeVisualizer == null)
            return;

        attackRangeVisualizer.useWorldSpace = false;
        DrawAttackRange();
        
    }

    private void Update()
    {
        attackTimer = attackTimer - Time.deltaTime;

        if (attackTimer >0f)
            return;

        Attack();

        attackTimer = GetAttackCooldown();
    }

    private float GetAttackCooldown()
    {
        return 1f/playerStats.AttackSpeed;
    }

    private void Attack()
    {
        Attacked?.Invoke();
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, playerStats.AttackRange, enemyPlayer);

        foreach(Collider2D hit in hits)
        {
            if (!hit.TryGetComponent<IDamageable>(out var damageable))
                continue;
            
            damageable.TakeDamage(playerStats.AttackDamage);
        }
    }

    


    //Temp
    [SerializeField] private LineRenderer attackRangeVisualizer;
    [SerializeField] private int circleSegments = 64;

    private void DrawAttackRange()
    {
        attackRangeVisualizer.positionCount = circleSegments + 1;
        attackRangeVisualizer.loop = true;

        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = i * Mathf.PI * 2f / circleSegments;

            Vector3 position = new Vector3(
                Mathf.Cos(angle),
                Mathf.Sin(angle),
                0f
            ) * playerStats.AttackRange;

            attackRangeVisualizer.SetPosition(i, position);
        }
    }
}
