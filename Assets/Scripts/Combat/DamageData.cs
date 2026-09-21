using UnityEngine;

public class DamageData 
{
    public float amount;

    public GameObject source;

    public DamageData(float amount, GameObject source)
    {
        this.amount = amount;
        this.source = source;
    }
}
