using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Dictionary<Type, IGameBehavior> behaviorsMap;
    private IGameBehavior behaviorCurrent;

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
        SetBehavior(behavior);
    }
    public void SetBehaviorRepeat()
    {
        var behavior = GetGameBehavior<GameBehaviorRepeat>();
        SetBehavior(behavior);
    }
    public void SetBehaviorCorrectAnswer()
    {
        var behavior = GetGameBehavior<GameBehaviorCorrectAnswer>();
        SetBehavior(behavior);
    }
    public void SetBehaviorWrongAnswer()
    {
        var behavior = GetGameBehavior<GameBehaviorWrongAnswer>();
        SetBehavior(behavior);
    }
}
