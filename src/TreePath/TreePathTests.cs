using NUnit.Framework;

namespace TreePath.Unit.Tests
{
	[TestFixture]
	public class TreePathTests
    {
		[Test]
		public void Should_add_root() {
			var rootNode = new Node("/");

			var node = rootNode.AddPath("/home/");

			Assert.That(node.ToString(), Is.EqualTo("home"));
		}

		[Test]
		public void Should_add_first_child() {
			var rootNode = new Node("/");
			var firstChild = rootNode.AddPath("/home/sports/");

			Assert.That(firstChild.GetChildren()[0].ToString(), Is.EqualTo("sports"));
		}
		[Test]
		public void Should_add_another_child() {

			var rootNode = new Node("/");
			rootNode.AddPath("/home/sports/");
			rootNode.AddPath("/home/music/");
			var anotherChild = rootNode.GetChildren()[0].GetChildren()[1];

			Assert.That(anotherChild.ToString(), Is.EqualTo("music"));

		}
    }
}
