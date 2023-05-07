using myNOC.EntityFramework.Query.Extensions;

namespace myNOC.Tests.EntityFramework.Query.Extensions
{
	[TestClass]
	public class IEnumerableExtensionsTests
	{
		[TestMethod]
		public void Apply_ExecutesAction_ReturnsIEnumerable()
		{
			//	Assemble
			var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
			var total = numbers.Sum();
			var calculated = 0;

			//	Act
			var results = numbers.AsEnumerable().Apply(x => calculated += x);

			//	Assert
			Assert.AreEqual(6, results.Count());
			Assert.AreEqual(total, calculated);
		}
	}
}
