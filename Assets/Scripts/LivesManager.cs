using UnityEngine;
using UnityEngine.Events;
public class LivesManager
{
    public delegate void LivesHandler(object sender, int newScoreValue);
    public static event LivesHandler OnLivesValueChangedEvent;

    public static int Lives { get; private set; } = 0;


    public static void SetLives(object sender, int amount)
    {
        Lives = Mathf.Clamp(amount, 0, 999);
    }

    public static void AddLives(object sender, int amount)
    {
        Lives = Mathf.Clamp(Lives + amount, 0, 999);

        OnLivesValueChangedEvent.Invoke(sender, Lives);
    }

    public static void SpendLives(object sender, int amount)
    {
        Lives = Mathf.Clamp(Lives - amount,0,999);

        OnLivesValueChangedEvent.Invoke(sender, Lives);
    }

    public static bool IsEnoughLives(int amount)
    {
        return amount <= Lives;
    }

}