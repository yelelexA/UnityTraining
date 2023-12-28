using UnityEngine;

using BehaviourTree;

public class CheckEnemyInFOVRange : Node
{
	private static int m_enemyLayerMask = 1 << 6;

	private Transform m_transform;

	public CheckEnemyInFOVRange(Transform transform)
	{
		m_transform = transform;
	}

	public override NodeState Evaluate()
	{
		object target = GetData("target");

		if (target == null)
		{
			Collider[] colliders = Physics.OverlapSphere(m_transform.position, GuardBT.fovRange, m_enemyLayerMask);

			if (colliders.Length > 0)
			{
				parent.parent.SetData("target", colliders[0].transform);

				state = NodeState.Success;
				return state;
			}

			state = NodeState.Failure;
			return state;
		}

		state = NodeState.Success;
		return state;
	}
}