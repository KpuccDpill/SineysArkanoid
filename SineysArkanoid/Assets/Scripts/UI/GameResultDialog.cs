using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResultDialog : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI congratsText;

    [Inject] private PlayerStats _playerStats;
    
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        congratsText.text = $"Эх, вы проиграли. Ваш результат - {_playerStats.Points} очков. Попробуйте ещё раз!";
    }
    
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneName.MainMenuScene);
    }
}
