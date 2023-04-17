using Microsoft.Extensions.DependencyInjection;

namespace myNOC.EntityFramework.Query.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddQueryPattern(this IServiceCollection services)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			var contextTypes = assemblies.SelectMany(x => x.GetTypes()).CanImplement(typeof(IQueryContext));
			var repositoryTypes = assemblies.SelectMany(x => x.GetTypes()).CanImplement(typeof(IQueryRepository));

			contextTypes.Apply(c => c.Interfaces.Apply(i => services.AddScoped(i, c.Type)));
			repositoryTypes.Apply(c => c.Interfaces.Apply(i => services.AddScoped(i, c.Type)));

			return services;
		}
	}
}
