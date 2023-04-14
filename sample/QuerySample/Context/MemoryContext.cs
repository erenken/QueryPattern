using Microsoft.EntityFrameworkCore;
using QuerySample.Entities;

namespace QuerySample.Context
{
	public class MemoryContext : DbContext
	{
		public DbSet<PersonEntity> Persons { get; set; }
	}
}
