using UnityEngine;

public class Hunter : MonoBehaviour
{
	[SerializeField] private float m_randomIdleRange = 25.0f;
	[SerializeField] private float m_randomMovementSpeed = 3.0f;
	[SerializeField] private float m_moveToFinderSpeed = 5.0f;

	[SerializeField] private float m_maxEnergy = 15.0f;

	[SerializeField] private Finder m_finder;

	private StateMachine m_stateMachine;
	private float m_currentEnergy;

	public float randomMovementSpeed => m_randomMovementSpeed;
	public float moveToFinderSpeed => m_moveToFinderSpeed;

	private void Awake()
	{
		m_stateMachine = new StateMachine();

		var idleState = new IdleState(this);

		m_stateMachine.SetState(idleState);
	}

	private void Start()
	{
		m_currentEnergy = m_maxEnergy;
	}

	private void Update()
	{

	}

	private void FixedUpdate()
	{
		//
	}

	public void SetEnergy(float newEnergy)
	{
		m_currentEnergy = newEnergy;
	}
}
