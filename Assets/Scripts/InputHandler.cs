using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static int playerToControl = 1;
    public PlayerController[] players;
    private Command _upArrow, _downArrow, _leftArrow, _rightArrow;

    private void Start()
    {
        DefineControls();
    }

    private void Update()
    {
        var input = HandleInput();

        input?.Execute(players[playerToControl - 1]);
    }


    private void DefineControls()
    {
        _upArrow = new FrontCommand();
        _downArrow = new BackCommand();
        _leftArrow = new LeftCommand();
        _rightArrow = new RightCommand();
    }

    private Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) return _upArrow;
        if (Input.GetKeyDown(KeyCode.DownArrow)) return _downArrow;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return _leftArrow;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return _rightArrow;

        return null;
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
