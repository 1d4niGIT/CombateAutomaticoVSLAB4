using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI xpText;

    private void Update()
    {
        if (player == null) return;

        healthBar.maxValue = player.Stats.MaxHealth;
        healthBar.value = player.Stats.CurrentHealth;
        xpText.text = $"XP: {player.Experience}";
    }
}
