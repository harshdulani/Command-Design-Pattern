using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static List<CommandBase> MoveHistory;

    public static int PlayerToControl = 1;

    public static int CurrentInMoveHistory
    {
        get => _currentInMoveHistory;
        set => _currentInMoveHistory = value = Mathf.Clamp(value, 0, MoveHistory.Count - 1);
    }

    private static int _currentInMoveHistory = 0;
    public PlayerController[] players;

    private void Start()
    {
        MoveHistory = new List<CommandBase>();
    }

    private void Update()
    {
        var input = HandleInput();

        if(input == null) return;
        
        AddToMoveHistory(input);
        input.Execute();
    }

    private CommandBase HandleInput()
    {
        var target = players[PlayerToControl - 1];

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var destZPos = target.ZPos + 1;
            return new MovePlayerCommand(target, target.XPos, destZPos);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var destZPos = target.ZPos - 1;
            return new MovePlayerCommand(target, target.XPos, destZPos);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var destXPos = target.XPos - 1;
            return new MovePlayerCommand(target, destXPos, target.ZPos);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var destXPos = target.XPos + 1;
            return new MovePlayerCommand(target, destXPos, target.ZPos);
        }

        return null;
    }

    private void AddToMoveHistory(CommandBase input)
    {
        if(MoveHistory.Count > 0)
            MoveHistory.RemoveRange(CurrentInMoveHistory, MoveHistory.Count - 1 - CurrentInMoveHistory);
        MoveHistory.Add(input);
        CurrentInMoveHistory = MoveHistory.Count - 1;
    }
}
