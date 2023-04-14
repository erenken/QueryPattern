namespace myNOC.EntityFramework.Query
{
	public interface IQueryContext
	{
		IQueryable<TEntity>Set<TEntity>() where TEntity : class;
	}
}
