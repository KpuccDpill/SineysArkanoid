using Reflex.Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelDialog : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;

    [Inject] private Level _level;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(StartNextLevel);
        
        _level.OnLevelComplete += Show;
    }

    private void Show()
    {
        throw new System.NotImplementedException();
    }

    private void StartNextLevel()
    {
        SceneManager.LoadScene(SceneName.GameScene);
    }
}
