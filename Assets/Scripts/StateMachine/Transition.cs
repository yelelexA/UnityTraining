public class Transition : ITransition
{
	public IState to { get; }
	public IState from { get; }
	public IPredicate condition { get; }

	public bool Execute(out IState stateToChange)
	{
		stateToChange = null;
		if (condition.Evaluate())
		{
			stateToChange = to;
			return true;
		}

		return false;
	}

	public Transition(IState from, IState to, IPredicate condition)
	{
		this.from = from;
		this.to = to;
		this.condition = condition;
	}
}