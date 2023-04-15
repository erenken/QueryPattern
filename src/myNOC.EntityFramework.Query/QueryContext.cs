using Microsoft.EntityFrameworkCore;

namespace myNOC.EntityFramework.Query
{
	public abstract class QueryContext : IQueryContext
	{
		public abstract DbContext GetContext();

		public IQueryable<TEntity> Set<TEntity>() where TEntity : class
		{
			return GetContext().Set<TEntity>();
		}
	}
}
