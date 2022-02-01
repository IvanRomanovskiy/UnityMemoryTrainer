using UnityEngine;
using System.Collections.Generic;

public class SequenceGenerator : MonoBehaviour
{
    private List<(int, int)> sequence;
    private static int pointer;
    
    [SerializeField] private ButtonGenerator generator;
    [SerializeField] private GameController controller;

    private void Awake()
    {
        ButtonGenerator.onButtonPressedEvent += ButtonPressed;
        ScoreManager.OnScoreValueChangedEvent += ScoreChanged;
        sequence = new List<(int, int)>();
    }

    private void ScoreChanged(int newScoreValue)
    {
        if (newScoreValue == 0)
        {
            sequence.Clear();
            pointer = 0;
        }
        AddRandomValueInSequence(newScoreValue);
    }

    private void AddRandomValueInSequence(int newScoreValue)
    {
        for(int i = sequence.Count; i < newScoreValue + 1; i++)
        {
            sequence.Add((Random.Range(0, generator.size), Random.Range(0, generator.size)));
        }
    }

    private void ButtonPressed(int i, int j)
    {
        if(controller.isBehavior(typeof(GameBehaviorRepeat)))
        {
            if (!checkSequence((i, j))) WrongAnswer(i,j);
        }
    }

    private void WrongAnswer(int i, int j)
    {
        pointer = 0;
        controller.SetBehaviorWrongAnswer();  
    }

    private bool checkSequence((int, int) val)
    {
        return val.Equals(sequence[pointer++]) ? true : false;
    }
}   