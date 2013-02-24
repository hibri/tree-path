using System.Collections.Generic;

namespace TreePath.Unit.Tests
{
	public class Combinations
	{
		public string[] FromArray(string[] strings) {
			var combinations = new List<string>();
			for (int index = 0; index < strings.Length; index++) {
				combinations.Add(strings[index]);
				for (int index2 = index + 1; index2 < strings.Length; index2++) {
					combinations.Add(strings[index] + "-" + strings[index2]);
					for (int index3 = index2 + 1; index3 < strings.Length; index3++) {
						combinations.Add(strings[index] + "-" + strings[index2] + "-" + strings[index3]);
					}
				}
			}

			combinations.Sort();
			combinations.Reverse();
			return combinations.ToArray();
		}
	}
}