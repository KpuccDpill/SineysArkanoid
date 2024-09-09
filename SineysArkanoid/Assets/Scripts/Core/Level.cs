using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Level
{
    private PlayerStats _playerStats;
    private Caret _caret;
    private List<Plank> _planks;
    private List<Ball> _balls;

    private NextLevelDialog _nextLevelDialog;
    private GameResultDialog _gameResultDialog;

    public Level(Caret caret, PlayerStats playerStats, NextLevelDialog nextLevelDialog, GameResultDialog gameResultDialog)
    {
        _caret = caret;
        _playerStats = playerStats;
        _nextLevelDialog = nextLevelDialog;
        _gameResultDialog = gameResultDialog;
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
            FinishLevel();    
            
            _gameResultDialog.Show();
        }
        else
        {
            _caret.ResetFirstBall();
        }
    }

    private void HandleLevelComplete()
    {
        FinishLevel();

        _nextLevelDialog.Show();
    }

    private void FinishLevel()
    {
        Plank.OnPlankDestroyed -= HandlePlankDestroy;
        Ball.OnBallDestroy -= HandleBallDestroy;
        
        _caret.gameObject.SetActive(false);

        foreach (var ball in _balls)
        {
            ball.gameObject.SetActive(false);
        }
    }
}
