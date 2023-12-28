using UnityEngine;

public class Finder : MonoBehaviour
{
	[SerializeField] private float m_randomIdleRange = 25.0f;
	[SerializeField] private float m_randomMovementSpeed = 5.0f;
	[SerializeField] private float m_moveToTreasureSpeed = 7.0f;

	[SerializeField] private Hunter m_hunter;
	[SerializeField] private GameObject m_treasure;

	private StateMachine m_stateMachine;

	public float randomMovementSpeed => m_randomMovementSpeed;
	public float moveToTreasureSpeed => m_moveToTreasureSpeed;

	private void Awake()
	{
		m_stateMachine = new StateMachine();

		var idleState = new IdleState(this);
		var moveToState = new MoveToState(this);
		var pickUpState = new PickUpState(this);

		// m_stateMachine.AddTransition(idleState, moveToState, new FuncPredicate(() => Vector3.Distance(transform.position, m_treasure.transform.position) < 0.001f));
		m_stateMachine.AddTransition(idleState, moveToState, new FuncPredicate(() => m_treasure.activeInHierarchy));
		m_stateMachine.AddTransition(moveToState, pickUpState, new FuncPredicate(() => Vector3.Distance(transform.position, m_treasure.transform.position) < 0.1f));
		m_stateMachine.AddTransition(pickUpState, idleState, new FuncPredicate(() => !m_treasure.activeInHierarchy));

		m_stateMachine.SetState(idleState);
	}

	private void Start()
	{
		//
	}

	private void Update()
	{
		m_stateMachine.FrameUpdate();
	}

	private void FixedUpdate()
	{
		//
	}

	public void MoveTo(Vector3 targetPos, float speed)
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
	}

	public Vector3 GenerateRandomTargetPoint()
	{
		var circlePoint = Random.insideUnitCircle * m_randomIdleRange;

		return new Vector3(circlePoint.x, 0.5f, circlePoint.y);
	}

	public Vector3 GetTreasurePosition()
	{
		return m_treasure.transform.position;
	}

	public void PickUpTreasure()
	{
		m_treasure.SetActive(false);
	}
}
