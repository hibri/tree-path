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

		public static Node BuildTree(string path) {
			string[] pathElements = path.Split('/');
		
			string rootNodeValue = pathElements[1];

			var rootNode = new Node(rootNodeValue);
			var nextNodePath = path.Remove(0, + rootNodeValue.Length + 1);
			if (nextNodePath.Length > 1) {
				rootNode.AddChild(Node.BuildTree(nextNodePath));
			}
			return rootNode;
		}
	}
}