using System.Collections.Generic;
using System.Text;

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

			string[] leafNodes = nodeValue.Split('|');
			if (HasDualLeafNodes(leafNodes)) {
				AddDualLeafNodes(leafNodes);
				return null;
			}
			if (HasCombinatorialNodes(leafNodes)) {
				AddCombinatorialNodes(leafNodes);
				return null;
			}
			return AddSingleLeafNode(path, nodeValue);
		}

		private void AddCombinatorialNodes(string[] leafNodes) {
			string[] leafNodeCombinations = new Combinations().FromArray(leafNodes);
			foreach (var leafNode in leafNodeCombinations) {
				AddChild(new Node(leafNode));
			}
		}

		private bool HasCombinatorialNodes(string[] leafNodes) {
			return leafNodes.Length > 2;
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
			return dualLeafNodes.Length == 2;
		}

		private static string GetFirstPathElement(string path) {
			string[] pathElements = path.Split('/');

			string nodeValue = pathElements[1];
			return nodeValue;
		}
	}

	public class Combinations
	{
		public string[] FromArray(string[] strings) {
			List<string> combinations = new List<string>();
			for (int index = 0; index < strings.Length; index++) {
				combinations.Add(strings[index] );
				for (int index2 = index+1; index2 < strings.Length; index2++) {
					combinations.Add(strings[index] +"-"+ strings[index2]);
					for (int index3 = index2 + 1; index3 < strings.Length; index3++) {
						combinations.Add(strings[index] + "-" + strings[index2] +"-" + strings[index3]);
					}
				}
				
			}
			 
			combinations.Sort();
			combinations.Reverse();
			return combinations.ToArray();
		}
	}
}