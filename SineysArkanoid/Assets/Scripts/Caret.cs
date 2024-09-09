using UnityEngine;

public class Caret : MonoBehaviour
{
    [SerializeField] private Ball firstBall;
    public Ball FirstBall => firstBall;

    private Vector3 _defaultFirstBallPosition;

    private void Awake()
    {
        if (firstBall != null)
            _defaultFirstBallPosition = firstBall.transform.localPosition;
    }

    private void Update()
    {
        if (!firstBall.IsActive)
        {
            firstBall.transform.localPosition = _defaultFirstBallPosition;
            
            if (Input.GetMouseButtonDown(0))
            {
                firstBall.Activate();
            }
        }
    }

    public void ResetFirstBall()
    {
        firstBall.gameObject.SetActive(true);
        firstBall.ResetBall();
    }
}
