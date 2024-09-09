using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Level
{
    private PlayerStats _playerStats;
    private Caret _caret;
    private List<Plank> _planks;
    private List<Ball> _balls;

    public event Action OnLevelComplete;

    public Level(Caret caret, PlayerStats playerStats)
    {
        _caret = caret;
        _playerStats = playerStats;
    }

    public void InitLevel(List<Plank> planks)
    {
        _planks = planks;
        _balls = new List<Ball>();
        _balls.Add(_caret.FirstBall);

        Plank.OnPlankDestroyed += HandlePlankDestroy;
        Ball.OnBallDestroy += HandleBallDestroy;
    }

    private void HandlePlankDestroy(Plank plank)
    {
        _planks.Remove(plank);
        _playerStats.AddPoints(plank.points);

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
            SceneManager.LoadScene(SceneName.MainMenuScene);
        }
        else
        {
            _caret.ResetFirstBall();
        }
    }

    private void HandleLevelComplete()
    {
        UnsubscribeEvents();
        SceneManager.LoadScene(SceneName.GameScene);
    }

    private void UnsubscribeEvents()
    {
        Plank.OnPlankDestroyed -= HandlePlankDestroy;
        Ball.OnBallDestroy -= HandleBallDestroy;
    }
}
