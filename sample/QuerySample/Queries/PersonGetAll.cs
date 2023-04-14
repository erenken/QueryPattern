using myNOC.EntityFramework.Query;
using QuerySample.Entities;
using QuerySample.Models;

namespace QuerySample.Queries
{
	public class PersonGetAll : IQueryList<PersonModel>
	{
		public PersonGetAll() { }

		public IQueryable<PersonModel> Query(IQueryContext context)
		{
			var persons = context.Set<PersonEntity>();
			var query = from p in persons
						select new PersonModel
						{
							Id = p.Id,
							Name = p.Name,
							DisplayName = $"{p.Id} - {p.Name}"
						};

			return query;
		}
	}
}
