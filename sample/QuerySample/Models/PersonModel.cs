using System.Globalization;

namespace QuerySample.Models
{
	public class PersonModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = default!;
		public string DisplayName { get; set; } = default!;
	}
}
