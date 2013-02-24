using System.Collections.Generic;

namespace TreePath.Unit.Tests
{
	public class Node
	{
		private readonly string _nodeValue;
		private List<Node> _children = new List<Node>();

		public Node(string nodeValue) {
			_nodeValue = nodeValue;
		}
		public override string ToString()
		{
			return _nodeValue;
		}

		public void AddChild(Node node) {
			_children.Add(node);
		}

		public IList<Node> GetChildren() {
			return _children;
		}
	}
}