using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerController myController;
    private Command upArrow, downArrow, leftArrow, rightArrow;

    private void Start()
    {
        myController = GetComponent<PlayerController>();
        DefineControls();
    }

    private void DefineControls()
    {
        upArrow = new FrontCommand();
        downArrow = new BackCommand();
        leftArrow = new LeftCommand();
        rightArrow = new RightCommand();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) upArrow.Execute(myController);
        if (Input.GetKeyDown(KeyCode.DownArrow)) downArrow.Execute(myController);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) leftArrow.Execute(myController);
        if (Input.GetKeyDown(KeyCode.RightArrow)) rightArrow.Execute(myController);
    }
}

public class LeftCommand : Command
{
    public override void Execute(PlayerController target)
    {
        target.MoveLeft();
    }
}

public class RightCommand : Command
{
    public override void Execute(PlayerController target)
    {
        target.MoveRight();
    }
}

public class FrontCommand : Command
{
    public override void Execute(PlayerController target)
    {
        target.MoveForward();
    }
}

public class BackCommand : Command
{
    public override void Execute(PlayerController target)
    {
        target.MoveBack();
    }
}
