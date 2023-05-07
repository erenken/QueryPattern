using Microsoft.EntityFrameworkCore;
using myNOC.EntityFramework.Query;
using NSubstitute;
using System.ComponentModel.DataAnnotations;

namespace myNOC.Tests.EntityFramework.Query
{
	[TestClass]
	public class QueryContextTests
	{
		private TestContext _testDbContext = default!;
		private QueryContext _queryContext = Substitute.ForPartsOf<QueryContext>();

		[TestInitialize]
		public void Initialize()
		{
			var options = new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase("testContext").Options;
			_testDbContext = new TestContext(options);
		}


		[TestCleanup]
		public void Cleanup()
		{
			_testDbContext?.Database?.EnsureDeleted();
			_testDbContext?.Dispose();
		}

		[TestMethod]
		public void Set_Returns_Entity()
		{
			//	Assemble
			_queryContext.GetContext().Returns(_testDbContext);

			//	Act
			var result = _queryContext.Set<TestEntity>();

			//	Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType<IQueryable<TestEntity>>(result);
		}

		public class TestEntity
		{
			[Key]
			public int Id { get; set; }
		}

		public class TestContext : DbContext
		{
			public DbSet<TestEntity> TestEntities { get; set; } = default!;

			public TestContext(DbContextOptions options) : base(options) { }
		}
	}
}
