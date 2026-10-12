using UnityEngine;

public class FireEnemy : Enemy
{
    public override void TakeDamage(int damage, ElementType element)
    {
        float multiplier = element switch
        {
            ElementType.Fire => 0.5f,   // resistente
            ElementType.Water => 2f,     // muy débil
            ElementType.Rock => 2f, // muy débil
            ElementType.Wind => 0.5f, // resistente
            _ => 1f
        };

        Stats.ReceiveDamage(Mathf.RoundToInt(damage * multiplier));
        if (Stats.IsDead) Die();
    }
}
