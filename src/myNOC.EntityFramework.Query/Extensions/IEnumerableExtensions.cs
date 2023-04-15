namespace myNOC.EntityFramework.Query.Extensions
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> Apply<T>(this IEnumerable<T> values, Action<T> action)
		{
			foreach(var item in values)
				action(item);

			return values;
		}
	}
}
