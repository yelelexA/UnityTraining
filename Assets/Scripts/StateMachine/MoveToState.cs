using UnityEngine;

public class MoveToState : BaseState
{
	private Vector3 m_targetPos;

	public MoveToState(Finder finder) : base(finder)
	{

	}

	public override void OnEnter()
	{
		base.OnEnter();

		Debug.Log("MoveToState.Enter");

		m_targetPos = finder.GetTreasurePosition();
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		finder.MoveTo(m_targetPos, finder.moveToTreasureSpeed);
	}

	public override void OnExit()
	{
		base.OnExit();

		Debug.Log("MoveToState.OnExit");
	}
}