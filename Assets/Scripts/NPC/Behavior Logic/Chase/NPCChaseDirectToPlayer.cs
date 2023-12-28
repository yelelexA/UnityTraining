using UnityEngine;

[CreateAssetMenu(fileName = "Chase-Direct Chase", menuName = "NPC Logic/Chase Logic/Direct Chase")]
public class NPCChaseDirectToPlayer : NPCChaseSOBase
{
	[SerializeField] private float m_movementSpeed = 1.75f;

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

		Vector3 moveDirection = (playerTransform.position - npc.transform.position).normalized;

		npc.MoveNPC(moveDirection * m_movementSpeed);
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