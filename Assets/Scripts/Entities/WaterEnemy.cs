using UnityEngine;

public class WaterEnemy : Enemy
{
    public override void TakeDamage(int damage, ElementType element)
    {
        float multiplier = element switch
        {
            ElementType.Water => 0.5f,   // resistente
            ElementType.Fire => 2f,     // muy débil
            ElementType.Rock => 0.5f, // resistente
            ElementType.Wind => 1.5f, // débil
            _ => 1f
        };

        Stats.ReceiveDamage(Mathf.RoundToInt(damage * multiplier));
        if (Stats.IsDead) Die();
    }
}
