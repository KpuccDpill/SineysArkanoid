using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    private void Awake()
    {
        startGameButton.onClick.AddListener(OnClickStartGame);
    }

    private void OnClickStartGame()
    {
        SceneManager.LoadScene(SceneName.GameScene);
    }
}
