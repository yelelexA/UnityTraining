using UnityEngine;

public abstract class BaseState : IState
{
	protected readonly PlayerController playerController;
	protected readonly Finder finder;
	protected readonly Hunter hunter;

	protected BaseState(PlayerController playerController)
	{
		this.playerController = playerController;
	}

	protected BaseState(Finder finder)
	{
		this.finder = finder;
	}

	protected BaseState(Hunter hunter)
	{
		this.hunter = hunter;
	}

	public virtual void OnEnter()
	{

	}

	public virtual void FrameUpdate()
	{

	}

	public virtual void PhysicsUpdate()
	{

	}

	public virtual void OnExit()
	{

	}
}