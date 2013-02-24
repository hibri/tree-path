using System.Collections.Generic;

namespace TreePath.Unit.Tests
{
	public class Node
	{
		private readonly List<Node> _children = new List<Node>();
		private readonly string _nodeValue;

		public Node(string nodeValue) {
			_nodeValue = nodeValue;
		}

		public override string ToString() {
			return _nodeValue;
		}

		public Node AddChild(Node node) {
			foreach (Node child in _children) {
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
			string nodeValue = GetFirstPathElement(path);

			string[] dualLeafNodes = nodeValue.Split('|');
			if (HasDualLeafNodes(dualLeafNodes)) {
				AddDualLeafNodes(dualLeafNodes);
				return null;
			}
			return AddSingleLeafNode(path, nodeValue);
		}

		private Node AddSingleLeafNode(string path, string nodeValue) {
			var newNode = new Node(nodeValue);

			Node childNode = AddChild(newNode);
			string nextNodePath = path.Remove(0, +nodeValue.Length + 1);
			if (nextNodePath.Length > 1) {
				childNode.AddPath(nextNodePath);
			}
			return newNode;
		}

		private void AddDualLeafNodes(string[] dualLeafNodes) {
			foreach (string value in dualLeafNodes) {
				AddChild(new Node(value));
			}
		}

		private static bool HasDualLeafNodes(string[] dualLeafNodes) {
			return dualLeafNodes.Length > 1;
		}

		private static string GetFirstPathElement(string path) {
			string[] pathElements = path.Split('/');

			string nodeValue = pathElements[1];
			return nodeValue;
		}
	}
}