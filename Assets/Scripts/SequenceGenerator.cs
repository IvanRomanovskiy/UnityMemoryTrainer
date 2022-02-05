using UnityEngine;
using System.Collections.Generic;

public class SequenceGenerator : MonoBehaviour
{
    public List<(int, int)> sequence { get; private set; }
    public static int pointer;
    
    [SerializeField] private ButtonGenerator generator;
    [SerializeField] private GameController controller;

    
    private void Awake()
    {
        ScoreManager.OnScoreValueChangedEvent += ScoreChanged;
        sequence = new List<(int, int)>();
        AddRandomValueInSequence(0);
       
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

    public void AddRandomValueInSequence(int newScoreValue)
    {
        for(int i = sequence.Count; i < newScoreValue + 1; i++)
        {
            sequence.Add((Random.Range(0, generator.size), Random.Range(0, generator.size)));
        }
    }
}   