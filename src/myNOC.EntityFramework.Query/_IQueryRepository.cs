using Microsoft.EntityFrameworkCore;

namespace myNOC.EntityFramework.Query
{
	public interface IQueryRepository
	{
		public Task<IEnumerable<TModel>> Query<TModel>(IQueryList<TModel> query) where TModel : class;
		public Task<TReturn?> Query<TReturn>(IQueryScalar<TReturn> query);
	}
}
