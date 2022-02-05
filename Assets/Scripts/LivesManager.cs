using UnityEngine;
public class LivesManager
{
    public delegate void LivesHandler(int newLivesValue);
    public static event LivesHandler OnLivesValueChangedEvent;

    public static int Lives { get; private set; } = 0;


    public static void SetLives(int amount)
    {
        Lives = Mathf.Clamp(amount, 0, 999);

        OnLivesValueChangedEvent.Invoke(Lives);
    }

    public static void AddLives(int amount)
    {
        Lives = Mathf.Clamp(Lives + amount, 0, 999);

        OnLivesValueChangedEvent.Invoke(Lives);
    }

    public static void SpendLives(int amount)
    {
        Lives = Mathf.Clamp(Lives - amount,0,999);

        OnLivesValueChangedEvent.Invoke(Lives);
    }

    public static bool IsEnoughLives(int amount)
    {
        return amount <= Lives;
    }

}