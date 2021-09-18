using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static List<CommandBase> undoQueue;
    
    public static int PlayerToControl = 1;
    public PlayerController[] players;

    private void Start()
    {
        undoQueue = new List<CommandBase>();
    }

    private void Update()
    {
        var input = HandleInput();

        input?.Execute();
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
        
        if (undoQueue.Count == 0) return null;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            var x = undoQueue[undoQueue.Count - 1];
            undoQueue.RemoveAt(undoQueue.Count - 1);
            x.Undo();
        }

        return null;
    }
}
