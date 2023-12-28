using UnityEngine;

public class JumpState : BaseState
{
	public JumpState(PlayerController playerController) : base(playerController)
	{

	}

	public override void OnEnter()
	{
		base.OnEnter();

		Debug.Log("JumpState.OnEnter");
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		playerController.MoveUp();
	}
}