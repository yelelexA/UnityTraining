using BehaviourTree;
using UnityEngine;

public class TaskPatrol : Node
{
	private Transform m_transform;
	private Transform[] m_waypoints;

	private int m_currentWaypointIndex = 0;

	private float m_waitTime = 1.0f;
	private float m_waitCounter = 0.0f;
	private bool m_waiting = false;

	public TaskPatrol(Transform transform, Transform[] waypoints)
	{
		m_transform = transform;
		m_waypoints = waypoints;
	}

	public override NodeState Evaluate()
	{
		if (m_waiting)
		{
			m_waitCounter += Time.deltaTime;
			if (m_waitCounter >= m_waitTime)
			{
				m_waiting = false;
			}
		}
		else
		{
			Transform wp = m_waypoints[m_currentWaypointIndex];
			if (Vector3.Distance(m_transform.position, wp.position) < 0.01f)
			{
				m_transform.position = wp.position;
				m_waitCounter = 0.0f;
				m_waiting = true;

				m_currentWaypointIndex = (m_currentWaypointIndex + 1) % m_waypoints.Length;
			}
			else
			{
				m_transform.position = Vector3.MoveTowards(m_transform.position, wp.position, GuardBT.speed * Time.deltaTime);
				m_transform.LookAt(wp.position);
			}
		}

		state = NodeState.Running;
		return state;
	}
}