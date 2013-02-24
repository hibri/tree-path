using NUnit.Framework;

namespace TreePath.Unit.Tests
{
	[TestFixture]
	public class TreePathTests
    {
		[Test]
		public void Should_add_root() {
			var node = BuildTree("/home/");

			Assert.That(node.ToString(), Is.EqualTo("home"));
		}

		[Test]
		public void Should_add_first_child() {
			var first_leaf = BuildTree("/home/sports/");

			Assert.That(first_leaf.GetChildren()[0].ToString(), Is.EqualTo("sports"));
		}

		private Node BuildTree(string path) {
			string[] pathElements = path.Split('/');
			string rootNodeValue = pathElements[1];

			var rootNode = new Node(rootNodeValue);
			rootNode.AddChild(new Node(pathElements[2]));
			return rootNode;
		}
    }
}
