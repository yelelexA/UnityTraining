using UnityEngine;

public class NPCIdleSOBase : ScriptableObject
{
	protected NPC npc;
	protected Transform transform;
	protected GameObject gameObject;

	protected Transform playerTransform;

	public virtual void Initialize(GameObject gameObject, NPC npc)
	{
		this.gameObject = gameObject;
		transform = this.gameObject.transform;
		this.npc = npc;

		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public virtual void DoEnterLogic()
	{

	}

	public virtual void DoExitLogic()
	{
		ResetValues();
	}

	public virtual void DoFrameUpdateLogic()
	{
		if (npc.isAggroed)
		{
			npc.stateMachine.ChangeState(npc.chaseState);
		}
	}

	public virtual void DoPhysicsLogic()
	{

	}

	public virtual void ResetValues()
	{

	}
}