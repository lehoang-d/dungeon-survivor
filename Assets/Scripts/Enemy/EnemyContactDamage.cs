using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] private float damage =10f;
    [SerializeField] private float damageCooldown =1f;

    private float lastDamageTime;

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Player"))
            return;
        if (Time.time < lastDamageTime + damageCooldown)
            return;

        if(!collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            return;

        damageable.TakeDamage(damage);
        lastDamageTime = Time.time;
    }

    public void SetDamageMultiplier(float multiplier)
    {
        damage *= multiplier;
    }


}
