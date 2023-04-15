using Microsoft.EntityFrameworkCore;
using myNOC.EntityFramework.Query;
using QuerySample.Entities;

namespace QuerySample.Queries
{
	internal class ContactGetIdByName : IQueryScalar<int>
	{
		private readonly string _name;

		public ContactGetIdByName(string name)
		{
			_name = name;
		}

		public async Task<int> GetScalar(IQueryContext context)
		{
			var persons = context.Set<ContactEntity>();
			var query = from p in persons
						where p.Name.Contains(_name, StringComparison.InvariantCultureIgnoreCase)
						select p.Id;

			return await query.FirstOrDefaultAsync();
		}
	}
}
