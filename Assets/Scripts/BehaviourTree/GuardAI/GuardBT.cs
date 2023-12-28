using System.Collections.Generic;

using BehaviourTree;

public class GuardBT : Tree
{
	public UnityEngine.Transform[] waypoints;

	public static float speed = 12.0f;
	public static float fovRange = 6.0f;
	public static float attackRange = 1.0f;

	protected override Node SetupTree()
	{
		Node root = new Selector(new List<Node>
		{
			new Sequence(new List<Node>
			{
				new CheckEnemyInAttackRange(transform),
				new TaskAttack(transform)
			}),
			new Sequence(new List<Node>
			{
				new CheckEnemyInFOVRange(transform),
				new TaskGoToTarget(transform)
			}),
			new TaskPatrol(transform, waypoints),
		});

		return root;
	}
}
