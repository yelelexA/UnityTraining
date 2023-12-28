using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Straight-Single Projectile", menuName = "NPC Logic/Attack Logic/Straight Single Projectile")]
public class NPCAttackSingleStraightProjectile : NPCAttackSOBase
{
	[SerializeField] private Rigidbody m_bulletPrefab;
	[SerializeField] private float m_timeBetweenShots = 2.0f;
	[SerializeField] private float m_timeTillExit = 3.0f;
	[SerializeField] private float m_distanceToCountExit = 6.0f;
	[SerializeField] private float m_bulletSpeed = 10.0f;

	private float m_timer;
	private float m_exitTimer;

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

		if (m_timer > m_timeBetweenShots)
		{
			m_timer = 0.0f;

			Vector3 dir = (playerTransform.position - npc.transform.position).normalized;

			Rigidbody bullet = Instantiate(m_bulletPrefab, npc.transform.position, Quaternion.identity);
			bullet.velocity = dir * m_bulletSpeed;
		}

		if (Vector3.Distance(playerTransform.transform.position, npc.transform.position) > m_distanceToCountExit)
		{
			m_exitTimer += Time.deltaTime;

			if (m_exitTimer > m_timeTillExit)
			{
				npc.stateMachine.ChangeState(npc.chaseState);
			}
		}
		else
		{
			m_exitTimer = 0.0f;
		}

		m_timer += Time.deltaTime;
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