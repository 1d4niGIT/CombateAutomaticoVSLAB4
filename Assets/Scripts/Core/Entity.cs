using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int attack = 10;
    [SerializeField] private float speed = 2f;

    public BaseStats Stats { get; private set; }

    protected virtual void Awake()
    {
        Stats = new BaseStats(maxHealth, attack, speed); // constructor parametrizado
    }

    public abstract void TakeDamage(int damage, ElementType element);

    protected virtual void Die() => Destroy(gameObject);
}