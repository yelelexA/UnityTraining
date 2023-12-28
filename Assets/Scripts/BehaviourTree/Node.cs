using System.Collections.Generic;

namespace BehaviourTree
{
	public enum NodeState
	{
		Running,
		Success,
		Failure
	}

	public class Node
	{
		protected NodeState state;

		public Node parent;
		protected List<Node> children = new();

		private Dictionary<string, object> m_dataContext = new();

		public Node()
		{
			parent = null;
		}

		public Node(List<Node> children)
		{
			foreach (var child in children)
			{
				Attach(child);
			}
		}

		private void Attach(Node node)
		{
			node.parent = this;
			children.Add(node);
		}

		public virtual NodeState Evaluate() => NodeState.Failure;

		public void SetData(string key, object value)
		{
			m_dataContext[key] = value;
		}

		public object GetData(string key)
		{
			if (m_dataContext.TryGetValue(key, out var value))
			{
				return value;
			}

			Node node = parent;
			while (node != null)
			{
				value = node.GetData(key);
				if (value != null)
				{
					return value;
				}

				node = node.parent;
			}

			return null;
		}

		public bool ClearData(string key)
		{
			if (m_dataContext.ContainsKey(key))
			{
				m_dataContext.Remove(key);
				return true;
			}

			Node node = parent;
			while (node != null)
			{
				bool cleared = node.ClearData(key);
				if (cleared)
				{
					return true;
				}

				node = node.parent;
			}

			return false;
		}
	}
}