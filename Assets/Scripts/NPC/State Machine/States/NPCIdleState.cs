using UnityEngine;

public class NPCIdleState : NPCState
{
	public NPCIdleState(NPC npc, NPCStateMachine stateMachine) : base(npc, stateMachine)
	{

	}

	public override void EnterState()
	{
		base.EnterState();

		npc.NPCIdleBaseInstance.DoEnterLogic();
	}

	public override void ExitState()
	{
		base.ExitState();

		npc.NPCIdleBaseInstance.DoExitLogic();
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		npc.NPCIdleBaseInstance.DoFrameUpdateLogic();
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();

		npc.NPCIdleBaseInstance.DoPhysicsLogic();
	}
}