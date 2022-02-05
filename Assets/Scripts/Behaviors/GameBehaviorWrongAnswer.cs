
using UnityEngine.UI;

public class GameBehaviorWrongAnswer : IGameBehavior
{
    ButtonGenerator buttonGenerator;
    SequenceGenerator sequenceGenerator;
    GameController controller;
    Text text;

    public GameBehaviorWrongAnswer(ButtonGenerator buttonGenerator, SequenceGenerator sequenceGenerator, GameController controller, Text text)
    {
        this.buttonGenerator = buttonGenerator;
        this.sequenceGenerator = sequenceGenerator;
        this.controller = controller;
        this.text = text;
    }


    public void Enter()
    {
        LivesManager.SpendLives(1);
        if (LivesManager.Lives <= 0)
        {
            text.text = "YOU LOSE";
            buttonGenerator.DisableAllButtons(true);
        }
        else controller.SetBehaviorMemorize();
    }

    public void Exit()
    {
       
    }

    public void Update()
    {
        
    }
}