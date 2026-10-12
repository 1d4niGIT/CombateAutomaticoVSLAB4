using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float attackInterval = 1f;
    [SerializeField] private LayerMask enemyLayer;
    public int Experience { get; private set; }

    private ElementType currentElement = ElementType.Fire; // 1) variable
    private float attackTimer;

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            AutoAttack();
            attackTimer = 0f;
        }
    }

    private void AutoAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Entity target))
                target.TakeDamage(Stats.Attack, currentElement);
        }
        NextElement(); // 3) se llama aquí, después de atacar
    }

    // 2) el método, a nivel de clase
    private void NextElement() =>
        currentElement = (ElementType)(((int)currentElement + 1) % 4);

    public override void TakeDamage(int damage, ElementType element)
    {
        Stats.ReceiveDamage(damage);
        Debug.Log($"Player vida: {Stats.CurrentHealth}/{Stats.MaxHealth}");
        if (Stats.IsDead) Die();
    }
    public void AddExperience(int amount)
    {
        Experience += amount;
        Debug.Log($"XP: {Experience}");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}