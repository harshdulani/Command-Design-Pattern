# Command-Design-Pattern

Implementation of Command Design Pattern in Unity
Learning from "Game Programming Patterns" book by Robert Nystrom

Devlog:
In this project, I have created an abstraction between handling the raw input to deciding what to do with the input.

"Command" can be useful in large projects where controls may be remapped. 
This can be achieved by creating a CommandBase class and deriving it in subclasses for every "command" you want an input to bind to.

You can add universality to the command by adding parameters to the Execute function of the command class.
For example: add a GameObject/PlayerController parameter to the function and you can choose to execute the function for all/either of the gameobjects.
This can be useful in multiplayer, turn based games.

The largest use case of the "Command"s can be the Undo/Redo functionality (refer to final commit code).
By transfering the universality of controller player from the command itself to the input handler, we have created an encapsulation of an entire Input request as a Command.
Now, since we have an object encapsulating the "Move"/Request via input, we can now also add statefulness to it by storing the previous state of the target in the Command itself.

Adding a List of moves to Undo and Redo through becomes pretty easy after that.

Functionality Explanation:
A singular InputHandler for both players is used as opposed to both having separate ones and checking a bool on every frame regarding their turn being active or no.
The InputHandler now checks the active player and sends Commands to their PlayerController.

In future if there were to be more moves to be made, such as, jumping, attacking, dodging etc, all those would be contained within their PlayerControllers themselves.
The nature of the moves and the details would be sent as parameters from the InputHandler via the commands.