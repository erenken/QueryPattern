using Microsoft.Extensions.DependencyInjection;

namespace myNOC.EntityFramework.Query
{
	public static class IServiceCollectionExtensions
    {
		public static IServiceCollection AddQueryPattern(this IServiceCollection services)
		{
			services.AddScoped<IQueryContext, QueryContext>();
			services.AddScoped<IQueryRepository, QueryRepository>();

			return services;
		}
    }
}
