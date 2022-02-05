using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviorRepeat : IGameBehavior
{
    ButtonGenerator buttonGenerator;
    SequenceGenerator sequenceGenerator;
    GameController controller;
    Text text;

    public static int pointer;

    public GameBehaviorRepeat(ButtonGenerator buttonGenerator, SequenceGenerator sequenceGenerator,GameController controller, Text text)
    {
        this.buttonGenerator = buttonGenerator;
        this.sequenceGenerator = sequenceGenerator;
        this.controller = controller;
        this.text = text;
        ButtonGenerator.onButtonPressedEvent += ButtonPressed;
    }

    public void Enter()
    {
        pointer = 0;
        buttonGenerator.DisableAllButtons(false);
        text.text = "REPEAT";
    }

    public void Exit()
    {
       
    }

    public void Update()
    {
      
    }

    private void WrongAnswer(int i, int j)
    {
        controller.SetBehaviorWrongAnswer();
    }
    private void ButtonPressed(int i, int j)
    {
        if (controller.isBehavior(typeof(GameBehaviorRepeat)))
        {
            if (!checkSequence((i, j), sequenceGenerator.sequence))
            {
                WrongAnswer(i, j);
                return;
            }
            if (sequenceGenerator.sequence.Count == pointer) controller.SetBehaviorCorrectAnswer();
        }
    }
    private bool checkSequence((int, int) val, List<(int, int)> sequence)
    {
        return val.Equals(sequence[pointer++]) ? true : false;
    }
}