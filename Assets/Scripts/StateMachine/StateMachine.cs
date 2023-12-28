using System.Collections.Generic;

public class StateMachine
{
	private IState m_current;
	private HashSet<ITransition> m_anyTransitions = new();

	public void FrameUpdate()
	{
		foreach (var transition in m_anyTransitions)
		{
			if (transition.from == m_current)
			{
				if (transition.Execute(out var newState))
				{
					ChangeState(newState);
				}
			}
		}

		m_current?.FrameUpdate();
	}

	public void PhysicsUpdate()
	{
		m_current?.PhysicsUpdate();
	}

	public void SetState(IState state)
	{
		m_current = state;
		m_current?.OnEnter();
	}

	public void ChangeState(IState newState)
	{
		m_current?.OnExit();
		m_current = newState;
		m_current?.OnEnter();
	}

	public void AddTransition(IState from, IState to, IPredicate condition)
	{
		m_anyTransitions.Add(new Transition(from, to, condition));
	}
}