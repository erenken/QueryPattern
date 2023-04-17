// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using myNOC.EntityFramework.Query.Extensions;
using QuerySample.Data;
using QuerySample.Entities;
using QuerySample.Queries;

await SeedSampleData();

IServiceCollection services = new ServiceCollection();
services.AddQueryPattern();

var provider = services.BuildServiceProvider();

var queryRepo = provider.GetRequiredService<IAddressBookContextRepository>();
var result = await queryRepo.Query(new ContactGetAll());
DisplayResults("Return All Contacts", result);

Console.WriteLine();

result = await queryRepo.Query(new ContactNameContains("a"));
DisplayResults("Contacts Where Name Contain 'a'", result);

Console.WriteLine();

var id = await queryRepo.Query(new ContactGetIdByName("Bob"));
Console.WriteLine($"Bob's Id is: {id}");

static async Task SeedSampleData()
{
	var addressBook = new AddressBookDbContext();
	addressBook.Add(new ContactEntity { Id = 1, Name = "Abby" });
	addressBook.Add(new ContactEntity { Id = 2, Name = "Bob" });
	addressBook.Add(new ContactEntity { Id = 3, Name = "Charlie" });
	addressBook.Add(new ContactEntity { Id = 4, Name = "David" });
	await addressBook.SaveChangesAsync();
}

static void DisplayResults(string title, IEnumerable<QuerySample.Models.ContactModel> result)
{
	Console.WriteLine(title);
	foreach (var item in result)
		Console.WriteLine(item.DisplayName);
}
