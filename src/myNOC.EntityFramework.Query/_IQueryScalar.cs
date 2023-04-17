namespace myNOC.EntityFramework.Query
{
	public interface IQueryScalar<TReturn>
	{
		Task<TReturn?> GetScalar(IQueryContext context); 
	}
}
