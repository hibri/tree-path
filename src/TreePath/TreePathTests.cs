using NUnit.Framework;

namespace TreePath.Unit.Tests
{
	[TestFixture]
	public class TreePathTests
    {
		[Test]
		public void Should_add_root() {
			var node = Node.BuildTree("/home/");

			Assert.That(node.ToString(), Is.EqualTo("home"));
		}

		[Test]
		public void Should_add_first_child() {
			var first_leaf = Node.BuildTree("/home/sports/");

			Assert.That(first_leaf.GetChildren()[0].ToString(), Is.EqualTo("sports"));
		}
    }
}
