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

		public Node AddChild(Node node) {
			foreach (var child in _children) {
				if (child.ToString() == node.ToString()) {
					return child;
				}
			}
			_children.Add(node);
			return node;
		}

		public IList<Node> GetChildren() {
			return _children;
		}

		public Node AddPath(string path) {
			var nodeValue = GetFirstPathElement(path);

			var newNode = new Node(nodeValue);

			var childNode = AddChild(newNode);
			var nextNodePath = path.Remove(0, + nodeValue.Length + 1);
			if (nextNodePath.Length > 1) {
				childNode.AddPath(nextNodePath);
			}
			return newNode;
		}

		private static string GetFirstPathElement(string path) {
			string[] pathElements = path.Split('/');

			string nodeValue = pathElements[1];
			return nodeValue;
		}
	}
}