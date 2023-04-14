namespace myNOC.EntityFramework.Query
{
	public interface IQueryList<TModel> where TModel : class
	{
		IQueryable<TModel> Query(IQueryContext context);
	}
}
