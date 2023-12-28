using UnityEngine;

public class NPCChaseState : NPCState
{
	public NPCChaseState(NPC npc, NPCStateMachine stateMachine) : base(npc, stateMachine)
	{

	}

	public override void EnterState()
	{
		base.EnterState();

		npc.NPCChaseBaseInstance.DoEnterLogic();
	}

	public override void ExitState()
	{
		base.ExitState();

		npc.NPCChaseBaseInstance.DoExitLogic();
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		npc.NPCChaseBaseInstance.DoFrameUpdateLogic();
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();

		npc.NPCChaseBaseInstance.DoPhysicsLogic();
	}
}