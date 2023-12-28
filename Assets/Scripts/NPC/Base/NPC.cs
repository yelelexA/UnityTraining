using System;
using UnityEngine;

public class NPC : MonoBehaviour, IDamageable, IMoveable, ITriggerCheckable
{
	[field: SerializeField] public float maxHealth { get; set; } = 100.0f;
	public float currentHealth { get; set; }
	public Rigidbody rigidbody { get; set; }

	public NPCStateMachine stateMachine { get; set; }
	public NPCIdleState idleState { get; set; }
	public NPCChaseState chaseState { get; set; }
	public NPCAttackState attackState { get; set; }

	public bool isAggroed { get; set; }
	public bool isWithinStrikingDistance { get; set; }

	[SerializeField] private NPCIdleSOBase m_npcIdleBase;
	[SerializeField] private NPCChaseSOBase m_npcChaseBase;
	[SerializeField] private NPCAttackSOBase m_npcAttackBase;

	public NPCIdleSOBase NPCIdleBaseInstance { get; set; }
	public NPCChaseSOBase NPCChaseBaseInstance { get; set; }
	public NPCAttackSOBase NPCAttackBaseInstance { get; set; }

	private void Awake()
	{
		NPCIdleBaseInstance = Instantiate(m_npcIdleBase);
		NPCChaseBaseInstance = Instantiate(m_npcChaseBase);
		NPCAttackBaseInstance = Instantiate(m_npcAttackBase);

		stateMachine = new NPCStateMachine();

		idleState = new NPCIdleState(this, stateMachine);
		chaseState = new NPCChaseState(this, stateMachine);
		attackState = new NPCAttackState(this, stateMachine);
	}

	private void Start()
	{
		currentHealth = maxHealth;

		rigidbody = GetComponent<Rigidbody>();

		NPCIdleBaseInstance.Initialize(gameObject, this);
		NPCChaseBaseInstance.Initialize(gameObject, this);
		NPCAttackBaseInstance.Initialize(gameObject, this);

		stateMachine.Initialize(idleState);
	}

	private void Update()
	{
		stateMachine.currentState.FrameUpdate();
	}

	private void FixedUpdate()
	{
		stateMachine.currentState.PhysicsUpdate();
	}

	public void Damage(float damageAmount)
	{

	}

	public void Die()
	{

	}

	public void MoveNPC(Vector3 velocity)
	{
		rigidbody.velocity = velocity;
	}

	public void CheckDirection(Vector3 velocity)
	{

	}

	public void SetAggroStatus(bool isAggroed)
	{
		this.isAggroed = isAggroed;
	}

	public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
	{
		this.isWithinStrikingDistance = isWithinStrikingDistance;
	}
}
