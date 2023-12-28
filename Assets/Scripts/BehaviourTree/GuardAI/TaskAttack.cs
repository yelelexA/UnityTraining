using UnityEngine;

using BehaviourTree;

public class TaskAttack : Node
{
	private Transform m_lastTarget;
	private EnemyManager m_enemyManager;

	private float m_attackTime = 1.0f;
	private float m_attackCounter = 0.0f;
	private int m_power = 5;

	public TaskAttack(Transform transform)
	{

	}

	public override NodeState Evaluate()
	{
		Transform targetTransform = (Transform)GetData("target");

		if (targetTransform != m_lastTarget)
		{
			m_enemyManager = targetTransform.GetComponent<EnemyManager>();
			m_lastTarget = targetTransform;
		}

		m_attackCounter += Time.deltaTime;
		if (m_attackCounter >= m_attackTime)
		{
			bool enemyIsDead = m_enemyManager.TakeHit(m_power);
			if (enemyIsDead)
			{
				ClearData("target");
			}
			else
			{
				m_attackCounter = 0.0f;
			}
		}

		state = NodeState.Running;
		return state;
	}
}
