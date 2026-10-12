using UnityEngine;
[System.Serializable]
public class BaseStats
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int Attack { get; private set; }
    public float Speed { get; private set; }

    public BaseStats(int maxHealth, int attack, float speed)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        Attack = attack;
        Speed = speed;
    }

    public void ReceiveDamage(int amount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        Debug.Log($"Daño recibido: {CurrentHealth}/{MaxHealth}");
    }

    public void Heal(int amount)
    {
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        Debug.Log($"Curado: {CurrentHealth}/{MaxHealth}");
    }

    public bool IsDead => CurrentHealth <= 0;
}
