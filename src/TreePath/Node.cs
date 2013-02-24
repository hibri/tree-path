using System.Collections.Generic;
using System.Linq;

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
			string nextNodePath = GetNextNodePath(path, nodeValue);
			string[] leafNodes = nodeValue.Split('|');
			if (HasCombinatorialNodes(leafNodes) && HasMoreNodesInPath(nextNodePath))
			{
				AddCombinatorialNodes(leafNodes);
 				foreach (var child in _children) {

 					child.AddPath(nextNodePath);
 				}
				return null;
			}
			else if (HasCombinatorialNodes(leafNodes)) {
				AddCombinatorialNodes(leafNodes);
				return null;
			}
		

			
			return AddSingleLeafNode(path, nodeValue);
		}

		public void AddCombinatorialNodes(string[] leafNodes) {
			string[] leafNodeCombinations = new Combinations().FromArray(leafNodes);
			foreach (string leafNode in leafNodeCombinations) {
				AddChild(new Node(leafNode));
			}
		}

		private bool HasCombinatorialNodes(string[] leafNodes) {
			return leafNodes.Length > 1;
		}

		private Node AddSingleLeafNode(string path, string nodeValue) {
			var newNode = new Node(nodeValue);

			Node childNode = AddChild(newNode);
			var nextNodePath = GetNextNodePath(path, nodeValue);
			if (HasMoreNodesInPath(nextNodePath)) {
				childNode.AddPath(nextNodePath);
			}
			return newNode;
		}

		private static bool HasMoreNodesInPath(string nextNodePath) {
			return nextNodePath.Length > 1;
		}

		private static string GetNextNodePath(string path, string nodeValue) {
			string nextNodePath = path.Remove(0, +nodeValue.Length + 1);
			return nextNodePath;
		}

		private void AddDualLeafNodes(string[] dualLeafNodes) {
			foreach (string value in dualLeafNodes) {
				AddChild(new Node(value));
			}
		}

		private static string GetFirstPathElement(string path) {
			string[] pathElements = path.Split('/');

			string nodeValue = pathElements[1];
			return nodeValue;
		}

		public  Node FindNode(string nodeValue) {
			return _children.SingleOrDefault(n => n.ToString() == nodeValue);
		}
	}
}