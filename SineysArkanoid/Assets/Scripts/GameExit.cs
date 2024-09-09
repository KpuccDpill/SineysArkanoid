using UnityEngine;

public class GameExit : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
