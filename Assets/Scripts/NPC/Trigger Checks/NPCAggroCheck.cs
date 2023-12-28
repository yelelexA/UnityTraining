using UnityEngine;

public class NPCAggroCheck : MonoBehaviour
{
	public GameObject playerTarget { get; set; }
	private NPC m_npc;

	private void Awake()
	{
		playerTarget = GameObject.FindGameObjectWithTag("Player");

		m_npc = GetComponentInParent<NPC>();
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject == playerTarget)
		{
			m_npc.SetAggroStatus(true);
		}
	}

	private void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject == playerTarget)
		{
			m_npc.SetAggroStatus(false);
		}
	}
}