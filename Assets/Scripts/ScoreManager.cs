using UnityEngine;

public class ScoreManager
{
    public delegate void ScoreHandler(int newScoreValue);
    public static event ScoreHandler OnScoreValueChangedEvent;

    public static int Score { get; private set; }

    public static void AddScore(int amount)
    {
        Score = Mathf.Clamp(Score + amount, 0, 999);

        OnScoreValueChangedEvent?.Invoke(Score);
    }

    public static void ClearScore()
    {
        Score = 0;

        OnScoreValueChangedEvent?.Invoke(Score);
    }

    public bool IsEnoughScore(int amount)
    {
        return amount <= Score;
    }

}