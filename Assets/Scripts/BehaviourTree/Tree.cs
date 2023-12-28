using UnityEngine;

namespace BehaviourTree
{
	public abstract class Tree : MonoBehaviour
	{
		private Node m_root = null;

		protected void Start()
		{
			m_root = SetupTree();
		}

		private void Update()
		{
			m_root?.Evaluate();
		}

		protected abstract Node SetupTree();
	}
}