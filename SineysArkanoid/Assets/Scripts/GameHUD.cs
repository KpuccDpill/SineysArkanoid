using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI livesText;

    [Inject] private PlayerStats _playerStats;

    private void Awake()
    {
        _playerStats.OnAttemptLost += OnAttemptsAmountChanged;
        _playerStats.OnPointsChanged += OnPointsChanged;
        
        OnPointsChanged();
        OnAttemptsAmountChanged();
    }

    private void OnPointsChanged()
    {
        pointsText.text = $"Очки: {_playerStats.Points}";
    }

    private void OnAttemptsAmountChanged()
    {
        livesText.text = $"Жизни: {_playerStats.AttemptsLeft}";
    }
}
