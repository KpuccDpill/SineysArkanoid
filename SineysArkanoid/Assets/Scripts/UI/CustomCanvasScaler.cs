using UnityEngine;
using UnityEngine.UI;

public class CustomCanvasScaler : MonoBehaviour
{
    private void Awake()
    {
        var canvasScaler = GetComponent<CanvasScaler>();
        
        var screenRatio = Screen.width / (float)Screen.height;
        canvasScaler.matchWidthOrHeight = screenRatio > 1.75f ? 1 : 0;
    }
}
