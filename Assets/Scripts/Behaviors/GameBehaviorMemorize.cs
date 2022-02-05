using System;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviorMemorize : IGameBehavior
{
    ButtonGenerator buttonGenerator;
    SequenceGenerator sequenceGenerator;
    Text text;

    public GameBehaviorMemorize(ButtonGenerator buttonGenerator, SequenceGenerator sequenceGenerator, Text text)
    {
        this.buttonGenerator = buttonGenerator;
        this.sequenceGenerator = sequenceGenerator;
        this.text = text;
    }
    public void Enter()
    {
        buttonGenerator.DisableAllButtons(true);
        text.text = "MEMORIZE";
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }

}