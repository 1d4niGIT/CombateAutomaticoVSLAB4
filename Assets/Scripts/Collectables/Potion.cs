using UnityEngine;

public class Potion : Collectable
{
    [SerializeField] private int healAmount = 25;
    protected override void OnCollected(Player player) => player.Stats.Heal(healAmount);
}
