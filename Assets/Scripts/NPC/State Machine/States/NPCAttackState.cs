using System.Timers;
using UnityEngine;

public class NPCAttackState : NPCState
{
	public NPCAttackState(NPC npc, NPCStateMachine stateMachine) : base(npc, stateMachine)
	{

	}

	public override void EnterState()
	{
		base.EnterState();

		npc.NPCAttackBaseInstance.DoEnterLogic();
	}

	public override void ExitState()
	{
		base.ExitState();

		npc.NPCAttackBaseInstance.DoExitLogic();
	}

	public override void FrameUpdate()
	{
		base.FrameUpdate();

		npc.NPCAttackBaseInstance.DoFrameUpdateLogic();
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();

		npc.NPCAttackBaseInstance.DoPhysicsLogic();
	}
}
