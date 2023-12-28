using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Random Wander", menuName = "NPC Logic/Idle Logic/Random Wander")]
public class NPCIdleRandomWander : NPCIdleSOBase
{
	[SerializeField] private float m_randomMovementRange = 5.0f;
	[SerializeField] private float m_randomMovementSpeed = 1.0f;

	private Vector3 m_targetPos;
	private Vector3 m_direction;

	public override void Initialize(GameObject gameObject, NPC npc)
	{
		base.Initialize(gameObject, npc);
	}

	public override void DoEnterLogic()
	{
		base.DoEnterLogic();

		m_targetPos = GetRandomMovementPoint();
	}

	public override void DoExitLogic()
	{
		base.DoExitLogic();
	}

	public override void DoFrameUpdateLogic()
	{
		base.DoFrameUpdateLogic();

		m_direction = (m_targetPos - npc.transform.position).normalized;
		npc.MoveNPC(m_direction * m_randomMovementSpeed);

		if ((npc.transform.position - m_targetPos).sqrMagnitude < 0.01f)
		{
			m_targetPos = GetRandomMovementPoint();
		}
	}

	public override void DoPhysicsLogic()
	{
		base.DoPhysicsLogic();
	}

	public override void ResetValues()
	{
		base.ResetValues();
	}

	private Vector3 GetRandomMovementPoint()
	{
		Vector2 randomPoint = Random.insideUnitSphere * m_randomMovementRange;
		Vector3 targetPos;
		targetPos.x = randomPoint.x + npc.transform.position.x;
		targetPos.y = 0.5f;
		targetPos.z = randomPoint.y + npc.transform.position.z;
		return targetPos;
	}
}