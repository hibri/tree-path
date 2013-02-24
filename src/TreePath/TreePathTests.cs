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

		[Test]
		public void Should_add_many_children_and_grand_children() {
			var rootNode = new Node("/");
			rootNode.AddPath("/home/sports/basketball");
			rootNode.AddPath("/home/sports/football");
			rootNode.AddPath("/home/sports/basketball/NCAA");

			rootNode.AddPath("/home/music/");
			rootNode.AddPath("/home/music/rap");
			rootNode.AddPath("/home/music/rock");
			rootNode.AddPath("/home/music/rap/gangster");

			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].ToString(), Is.EqualTo("sports"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].GetChildren()[0].ToString(), Is.EqualTo("basketball"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].GetChildren()[1].ToString(), Is.EqualTo("football"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].GetChildren()[0].GetChildren()[0].ToString(), Is.EqualTo("NCAA"));

			Assert.That(rootNode.GetChildren()[0].GetChildren()[1].ToString(), Is.EqualTo("music"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[1].GetChildren()[0].ToString(), Is.EqualTo("rap"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[1].GetChildren()[1].ToString(), Is.EqualTo("rock"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[1].GetChildren()[0].GetChildren()[0].ToString(), Is.EqualTo("gangster"));

		}

		[Test]
		public void Should_support_dual_leaf_nodes() {
			var rootNode = new Node("/");
			rootNode.AddPath("/home/sports/basketball");
			rootNode.AddPath("/home/sports/football");
			rootNode.AddPath("/home/sports/basketball/NCAA");
			rootNode.AddPath("/home/sports/football/NFL|NCAA");

			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].ToString(), Is.EqualTo("sports"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].GetChildren()[0].ToString(), Is.EqualTo("basketball"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].GetChildren()[1].ToString(), Is.EqualTo("football"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].GetChildren()[1].GetChildren()[0].ToString(), Is.EqualTo("NFL"));
			Assert.That(rootNode.GetChildren()[0].GetChildren()[0].GetChildren()[1].GetChildren()[1].ToString(), Is.EqualTo("NCAA"));


		}
    }
}
