using Microsoft.EntityFrameworkCore;
using QuerySample.Entities;

namespace QuerySample.Data
{
	public class AddressBookDbContext : DbContext
	{
		public DbSet<ContactEntity> Contacts { get; set; } = default!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("AddressBook");
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
