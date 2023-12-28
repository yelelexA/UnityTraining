using UnityEngine;

public class PickUpState : BaseState
{
	private float m_pickUpTime = 2.0f;
	private float m_timer;

	public PickUpState(Finder finder) : base(finder)
	{

	}

	public override void OnEnter()
	{
		base.OnEnter();

		Debug.Log("PickUpState.Enter");
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		if (m_timer > m_pickUpTime)
		{
			m_timer = 0.0f;

			finder.PickUpTreasure();
		}

		m_timer += Time.deltaTime;
	}

	public override void OnExit()
	{
		base.OnExit();

		Debug.Log("PickUpState.OnExit");
	}
}