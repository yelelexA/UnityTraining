using UnityEngine;

public interface IMoveable
{
	Rigidbody rigidbody { get; set; }

	void MoveNPC(Vector3 velocity);
	void CheckDirection(Vector3 velocity);
}