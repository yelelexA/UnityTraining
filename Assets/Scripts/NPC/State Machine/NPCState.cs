public class NPCState
{
	protected NPC npc;
	protected NPCStateMachine stateMachine;

	public NPCState(NPC npc, NPCStateMachine stateMachine)
	{
		this.npc = npc;
		this.stateMachine = stateMachine;
	}

	public virtual void EnterState()
	{

	}

	public virtual void ExitState()
	{

	}

	public virtual void FrameUpdate()
	{

	}

	public virtual void PhysicsUpdate()
	{

	}
}