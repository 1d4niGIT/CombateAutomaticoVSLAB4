using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] private ElementType attackElement = ElementType.Fire;
    [SerializeField] private GameObject xpOrbPrefab;
    [SerializeField] private float contactCooldown = 0.5f;
    private Rigidbody2D rb;

    private Transform target;
    private float lastHitTime;

    protected override void Awake()
    {
        base.Awake(); // importante: crea los Stats
        rb = GetComponent<Rigidbody2D>();
        Player player = FindFirstObjectByType<Player>();
        if (player != null) target = player.transform;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Debug.DrawLine(rb.position, target.position, Color.green);

        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        rb.linearVelocity = direction * Stats.Speed;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (Time.time < lastHitTime + contactCooldown) return;

        if (col.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(Stats.Attack, attackElement);
            lastHitTime = Time.time;
        }
    }

    protected override void Die()
    {
        if (xpOrbPrefab != null)
            Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);
        base.Die();
    }
}
