using UnityEngine;

public class WindEnemy : Enemy
{
    public override void TakeDamage(int damage, ElementType element)
    {
        float multiplier = element switch
        {
            ElementType.Fire => 2f,   // muy débil
            ElementType.Water => 1.5f,     // débil
            ElementType.Rock => 0.5f, // resistente
            ElementType.Wind => 0.5f, // resistente
            _ => 1f
        };

        Stats.ReceiveDamage(Mathf.RoundToInt(damage * multiplier));
        if (Stats.IsDead) Die();
    }
}
