using UnityEngine;

[CreateAssetMenu(fileName = "Chase-Run Away", menuName = "NPC Logic/Chase Logic/Run Away")]
public class NPCChaseRunAway : NPCChaseSOBase
{
	[SerializeField] private float m_runAwaySpeed = 1.5f;

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

		Vector3 runDir = -(playerTransform.position - transform.position).normalized;
		npc.MoveNPC(runDir * m_runAwaySpeed);
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