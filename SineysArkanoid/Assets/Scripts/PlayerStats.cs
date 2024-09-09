using System;

public class PlayerStats
{
    private int _points;
    public int Points => _points;
    
    private int _attemptsLeft;
    public int AttemptsLeft => _attemptsLeft;

    private const int DefaultAttempts = 3;
    private const int DefaultPoints = 0;

    public event Action OnAttemptLost;
    public event Action OnPointsChanged;

    public PlayerStats()
    {
        _points = DefaultPoints;
        _attemptsLeft = DefaultAttempts;
    }
    
    public void SpendAttempt()
    {
        _attemptsLeft--;
        
        OnAttemptLost?.Invoke();
    }

    public void AddPoints(int points)
    {
        _points += points;
        
        OnPointsChanged?.Invoke();
    }
}
