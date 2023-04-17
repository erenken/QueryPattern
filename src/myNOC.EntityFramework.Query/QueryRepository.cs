using Microsoft.EntityFrameworkCore;

namespace myNOC.EntityFramework.Query
{
	public abstract class QueryRepository : IQueryRepository
	{
		private readonly IQueryContext _context;

		public QueryRepository(IQueryContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<TModel>> Query<TModel>(IQueryList<TModel> query) where TModel : class
		{
			var result = query.Query(_context);
			return await result.ToListAsync();
		}

		public async Task<TReturn?> Query<TReturn>(IQueryScalar<TReturn> query)
		{
			var result = await query.GetScalar(_context);
			return result;
		}
	}
}
