using UnityEngine;

public class XP : Collectable
{
    [SerializeField] private int xpAmount = 10;
    protected override void OnCollected(Player player) => player.AddExperience(xpAmount);
}
