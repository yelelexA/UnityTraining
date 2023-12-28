using UnityEngine;

using BehaviourTree;

public class CheckEnemyInAttackRange : Node
{
	private Transform m_transform;

	public CheckEnemyInAttackRange(Transform transform)
	{
		m_transform = transform;
	}

	public override NodeState Evaluate()
	{
		var target = GetData("target");

		if (target == null)
		{
			state = NodeState.Failure;
			return state;
		}

		Transform targetTransform = (Transform)target;
		if (Vector3.Distance(m_transform.position, targetTransform.position) <= GuardBT.attackRange)
		{
			state = NodeState.Success;
			return state;
		}

		state = NodeState.Failure;
		return state;
	}
}