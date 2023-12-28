using UnityEngine;

public class IdleState : BaseState
{
	private Vector3 m_targetPos;

	public IdleState(Finder finder) : base(finder)
	{

	}

	public IdleState(Hunter hunter) : base(hunter)
	{

	}

	public override void OnEnter()
	{
		base.OnEnter();

		Debug.Log("IdleState.Enter");

		m_targetPos = finder.GenerateRandomTargetPoint();
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		finder.MoveTo(m_targetPos, finder.randomMovementSpeed);

		if (Vector3.Distance(finder.transform.position, m_targetPos) < 0.001f)
		{
			m_targetPos = finder.GenerateRandomTargetPoint();
		}
	}

	public override void OnExit()
	{
		base.OnExit();

		Debug.Log("IdleState.OnExit");
	}
}