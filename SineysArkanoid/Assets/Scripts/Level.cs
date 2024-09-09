using System;
using System.Collections.Generic;
using Reflex.Attributes;

public class Level
{
    private PlayerStats _playerStats;
    private Caret _caret;
    private List<Plank> _planks;
    private List<Ball> _balls;
    
    private const int PointsPerPlank = 100;

    public void InitLevel(List<Plank> planks, Caret caret, PlayerStats playerStats)
    {
        _playerStats = playerStats;
        _planks = planks;
        _caret = caret;
        _balls = new List<Ball>();
        _balls.Add(_caret.FirstBall);

        Plank.OnPlankDestroyed += HandlePlankDestroy;
        Ball.OnBallDestroy += HandleBallDestroy;
    }

    private void HandlePlankDestroy(Plank plank)
    {
        _planks.Remove(plank);
        
        _playerStats.AddPoints(PointsPerPlank);

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
        _playerStats.SpendAttempt();

        if (_playerStats.AttemptsLeft == 0)
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
