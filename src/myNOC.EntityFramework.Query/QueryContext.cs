using Microsoft.EntityFrameworkCore;

namespace myNOC.EntityFramework.Query
{
	public class QueryContext : IQueryContext
	{
		private readonly DbContext _dbContext;

		public QueryContext(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<TEntity> Set<TEntity>() where TEntity : class
		{
			return _dbContext.Set<TEntity>();
		}
	}
}
