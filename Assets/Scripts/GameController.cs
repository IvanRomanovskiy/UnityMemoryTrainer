using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text behaviorText;
    [SerializeField] ButtonGenerator buttonGenerator;
    [SerializeField] SequenceGenerator sequenceGenerator;

    private Dictionary<Type, IGameBehavior> behaviorsMap;
    private static IGameBehavior behaviorCurrent;
    private static Type typeCurrent;

    private void Start()
    {
        ScoreManager.ClearScore();
        LivesManager.SetLives(5);
        InitBehaviors();
        SetBehaviorByDefault();
    }

    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IGameBehavior>();

        behaviorsMap[typeof(GameBehaviorMemorize)] = new GameBehaviorMemorize(buttonGenerator,sequenceGenerator, behaviorText);
        behaviorsMap[typeof(GameBehaviorRepeat)] = new GameBehaviorRepeat(buttonGenerator, sequenceGenerator,this, behaviorText);
        behaviorsMap[typeof(GameBehaviorCorrectAnswer)] = new GameBehaviorCorrectAnswer(buttonGenerator, sequenceGenerator, this, behaviorText);
        behaviorsMap[typeof(GameBehaviorWrongAnswer)] = new GameBehaviorWrongAnswer(buttonGenerator, sequenceGenerator, this, behaviorText);

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
