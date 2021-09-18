public class MovePlayerCommand : CommandBase
{
	public MovePlayerCommand(PlayerController _player, float _x, float _z) => (player, x, z, prevX, prevZ) = (_player, _x, _z, 0, 0);

	public override void Execute()
	{
		prevX = player.XPos;
		prevZ = player.ZPos;
		
		player.MoveTo(x, z);
		InputHandler.undoQueue.Add(this);
	}

	public override void Undo()
	{
		player.MoveTo(prevX, prevZ);
	}
}