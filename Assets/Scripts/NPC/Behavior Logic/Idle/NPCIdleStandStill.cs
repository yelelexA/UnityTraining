using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Stand Still", menuName = "NPC Logic/Idle Logic/Stand Still")]
public class NPCIdleStandStill : NPCIdleSOBase
{
	public override void Initialize(GameObject gameObject, NPC npc)
	{
		base.Initialize(gameObject, npc);
	}

	public override void DoEnterLogic()
	{
		base.DoEnterLogic();
	}

	public override void DoExitLogic()
	{
		base.DoExitLogic();
	}

	public override void DoFrameUpdateLogic()
	{
		base.DoFrameUpdateLogic();

		npc.MoveNPC(Vector3.zero);
	}

	public override void DoPhysicsLogic()
	{
		base.DoPhysicsLogic();
	}

	public override void ResetValues()
	{
		base.ResetValues();
	}
}