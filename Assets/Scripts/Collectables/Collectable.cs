using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnCollected(player);
            Destroy(gameObject);
        }
    }

    protected abstract void OnCollected(Player player);
}
