using System.Collections.Generic;
using UnityEngine;

public interface IState
{
	void OnEnter();
	void FrameUpdate();
	void PhysicsUpdate();
	void OnExit();
}