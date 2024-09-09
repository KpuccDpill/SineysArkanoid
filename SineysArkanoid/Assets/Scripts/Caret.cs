using UnityEngine;

public class Caret : MonoBehaviour
{
    [SerializeField] private Ball firstBall;

    private Vector3 _defaultFirstBallPosition;

    private void Awake()
    {
        if (firstBall != null)
            _defaultFirstBallPosition = firstBall.transform.localPosition;
    }

    private void Update()
    {
        if (firstBall != null)
        {
            firstBall.transform.localPosition = _defaultFirstBallPosition;
            
            if (Input.GetMouseButtonDown(0))
            {
                firstBall.transform.parent = null;
                firstBall.IsActive = true;
                firstBall = null;
            }
        }
    }
}
