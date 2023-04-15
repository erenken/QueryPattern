using myNOC.EntityFramework.Query;
using QuerySample.Entities;
using QuerySample.Models;

namespace QuerySample.Queries
{
	internal class ContactGetAll : IQueryList<ContactModel>
	{
		public ContactGetAll() { }

		public IQueryable<ContactModel> Query(IQueryContext context)
		{
			var persons = context.Set<ContactEntity>();
			var query = from p in persons
						select new ContactModel
						{
							Id = p.Id,
							Name = p.Name,
							DisplayName = $"{p.Id} - {p.Name}"
						};

			return query;
		}
	}
}
