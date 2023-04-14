// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myNOC.EntityFramework.Query;
using QuerySample.Context;
using QuerySample.Entities;
using QuerySample.Queries;

using var addressBook = new MemoryContext();


IServiceCollection services = new ServiceCollection();
services.AddQueryPattern();
services.AddDbContext<MemoryContext>(opts => opts.UseInMemoryDatabase("AddresBook"));

var provider = services.BuildServiceProvider();

addressBook.Add<PersonEntity>(new PersonEntity { Id = 1, Name = "Abby" });
addressBook.Add<PersonEntity>(new PersonEntity { Id = 2, Name = "Bob" });
addressBook.Add<PersonEntity>(new PersonEntity { Id = 3, Name = "Charlie" });
addressBook.Add<PersonEntity>(new PersonEntity { Id = 4, Name = "David" });

var queryRepo = provider.GetRequiredService<IQueryRepository>();
var result = await queryRepo.Query(new PersonGetAll());

foreach(var item in result)
{
	Console.WriteLine(item.DisplayName);
}
