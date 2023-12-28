public interface ITransition
{
	IState to { get; }
	IState from { get; }
	IPredicate condition { get; }

	public bool Execute(out IState stateToChange);
}