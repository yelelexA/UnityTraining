using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float m_speed = 5.0f;

	private StateMachine m_stateMachine;
	private bool m_jumping = false;
	private bool m_moving = false;

	private void Awake()
	{
		m_stateMachine = new StateMachine();

		var locomotionState = new LocomotionState(this);
		var jumpState = new JumpState(this);

		At(locomotionState, jumpState, new FuncPredicate(() => m_jumping));
		At(jumpState, locomotionState, new FuncPredicate(() => m_moving));

		m_stateMachine.SetState(locomotionState);
	}

	private void Update()
	{
		m_stateMachine.FrameUpdate();

		if (transform.position.z >= 0.0f)
		{
			m_moving = false;
			m_jumping = true;
		}
	}

	public void MoveToward()
	{
		transform.Translate(Vector3.forward * (Time.deltaTime * m_speed));
	}

	public void MoveUp()
	{
		transform.Translate(Vector3.up * (Time.deltaTime * m_speed));
	}

	void At(IState from, IState to, IPredicate condition) => m_stateMachine.AddTransition(from, to, condition);
}