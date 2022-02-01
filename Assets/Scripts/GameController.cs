using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Dictionary<Type, IGameBehavior> behaviorsMap;
    private static IGameBehavior behaviorCurrent;
    private static Type typeCurrent;

    private void Start()
    {
        InitBehaviors();
        SetBehaviorByDefault();
    }

    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IGameBehavior>();

        behaviorsMap[typeof(GameBehaviorMemorize)] = new GameBehaviorMemorize();
        behaviorsMap[typeof(GameBehaviorRepeat)] = new GameBehaviorRepeat();
        behaviorsMap[typeof(GameBehaviorCorrectAnswer)] = new GameBehaviorCorrectAnswer();
        behaviorsMap[typeof(GameBehaviorWrongAnswer)] = new GameBehaviorWrongAnswer();

    }

    private void SetBehaviorByDefault()
    {
        SetBehaviorMemorize();
    }

    private void SetBehavior(IGameBehavior newBehavior)
    {
        if (behaviorCurrent != null)
            behaviorCurrent.Exit();

        behaviorCurrent = newBehavior;
        behaviorCurrent.Enter();
    }

    private IGameBehavior GetGameBehavior<T>() where T : IGameBehavior
    {
        return behaviorsMap[typeof(T)];
    }

    private void Update()
    {
        if (behaviorCurrent != null) behaviorCurrent.Update();
    }

    public void SetBehaviorMemorize()
    {
        var behavior = GetGameBehavior<GameBehaviorMemorize>();
        typeCurrent = typeof(GameBehaviorMemorize);
        SetBehavior(behavior);
    }

    public void SetBehaviorRepeat()
    {
        var behavior = GetGameBehavior<GameBehaviorRepeat>();
        typeCurrent = typeof(GameBehaviorRepeat);
        SetBehavior(behavior);
    }

    public void SetBehaviorCorrectAnswer()
    {
        var behavior = GetGameBehavior<GameBehaviorCorrectAnswer>();
        typeCurrent = typeof(GameBehaviorCorrectAnswer);
        SetBehavior(behavior);
    }

    public void SetBehaviorWrongAnswer()
    {
        var behavior = GetGameBehavior<GameBehaviorWrongAnswer>();
        typeCurrent = typeof(GameBehaviorWrongAnswer);
        SetBehavior(behavior);
    }

    public bool isBehavior(Type behavior)
    {
        if (typeCurrent.Equals(behavior)) return true;
        else return false;
    }

}
