using System;
using UnityEngine;

public class NPCStrikingDistanceCheck : MonoBehaviour
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
			m_npc.SetStrikingDistanceBool(true);
		}
	}

	private void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject == playerTarget)
		{
			m_npc.SetStrikingDistanceBool(false);
		}
	}
}