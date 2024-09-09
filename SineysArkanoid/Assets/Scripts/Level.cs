using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private List<Plank> _planks;
    private Caret _caret;
    private List<Ball> _balls;
    private int _attemptsLeft;
    
    private const int DefaultAttemptsAmount = 3;

    public void InitLevel(List<Plank> planks, Caret caret)
    {
        _planks = planks;
        _caret = caret;
        _balls = new List<Ball>();
        _balls.Add(_caret.FirstBall);

        _attemptsLeft = DefaultAttemptsAmount;

        Plank.OnPlankDestroyed += HandlePlankDestroy;
        Ball.OnBallDestroy += HandleBallDestroy;
    }

    private void HandlePlankDestroy(Plank plank)
    {
        _planks.Remove(plank);

        if (_planks.Count == 0)
            HandleLevelComplete();
    }

    private void HandleBallDestroy(Ball ball)
    {
        _balls.Remove(ball);

        if (_balls.Count == 0)
            HandleLevelFail();
    }

    private void HandleLevelFail()
    {
        _attemptsLeft--;

        if (_attemptsLeft == 0)
        {
            UnsubscribeEvents();    
        }
        else
        {
            _caret.ResetFirstBall();
        }
    }

    private void HandleLevelComplete()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        Plank.OnPlankDestroyed -= HandlePlankDestroy;
        Ball.OnBallDestroy -= HandleBallDestroy;
    }
}
