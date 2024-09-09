using Reflex.Attributes;
using UnityEngine;

public class Caret : MonoBehaviour
{
    [Inject] private Ball _firstBall;
    public Ball FirstBall => _firstBall;

    [Inject] private GameHUD _gameHud;

    private Vector3 _defaultFirstBallPosition;

    private void Awake()
    {
        if (_firstBall != null)
            _defaultFirstBallPosition = _firstBall.transform.localPosition;
    }

    private void Update()
    {
        if (!_firstBall.IsActive)
        {
            _firstBall.transform.localPosition = _defaultFirstBallPosition;
            
            if (Input.GetMouseButtonDown(0))
            {
                _firstBall.Activate();
                _gameHud.HideHintText();
            }
        }
    }

    public void ResetFirstBall()
    {
        _firstBall.gameObject.SetActive(true);
        _firstBall.ResetBall();
    }
}
