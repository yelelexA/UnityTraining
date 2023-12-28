using UnityEngine;

public class LocomotionState : BaseState
{
	public LocomotionState(PlayerController playerController) : base(playerController)
	{

	}

	public override void OnEnter()
	{
		base.OnEnter();

		Debug.Log("LocomotionState.OnEnter");
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		playerController.MoveToward();
	}
}