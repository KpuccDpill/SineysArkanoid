using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelDialog : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private TextMeshProUGUI congratsText;

    [Inject] private PlayerStats _playerStats;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(StartNextLevel);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        congratsText.text = $"Поздравляем! Ваш результат - {_playerStats.Points} очков. Продолжайте в том же духе!";
    }

    private void StartNextLevel()
    {
        SceneManager.LoadScene(SceneName.GameScene);
    }
}
