
using UnityEngine.UI;

public class GameBehaviorCorrectAnswer : IGameBehavior
{
    ButtonGenerator buttonGenerator;
    SequenceGenerator sequenceGenerator;
    GameController controller;
    Text text;

    public static int pointer;

    public GameBehaviorCorrectAnswer(ButtonGenerator buttonGenerator, SequenceGenerator sequenceGenerator, GameController controller, Text text)
    {
        this.buttonGenerator = buttonGenerator;
        this.sequenceGenerator = sequenceGenerator;
        this.controller = controller;
        this.text = text;
    }
    public void Enter()
    {
        ScoreManager.AddScore(1);
        controller.SetBehaviorMemorize();
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}