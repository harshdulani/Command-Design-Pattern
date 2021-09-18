public class CommandBase
{
	protected PlayerController player;
	protected float x, z, prevX, prevZ;

	protected CommandBase() { }
	
	public virtual void Execute() { }
	
	public virtual void Undo() {}
}
