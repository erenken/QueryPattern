using Microsoft.EntityFrameworkCore;
using myNOC.EntityFramework.Query;
using NSubstitute;
using System.ComponentModel.DataAnnotations;

namespace myNOC.Tests.EntityFramework.Query
{
	[TestClass]
	public class QueryRepositoryTests
	{
		private QueryContext _queryContext = default!;
		private TestContext _testDbContext = default!;
		private QueryRepository _queryRepository = default!;

		[TestInitialize]
		public void Initialize()
		{
			var options = new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase("testRepository").Options;
			_testDbContext = new TestContext(options);
			_testDbContext.TestEntities.Add(new TestEntity());
			_testDbContext.TestEntities.Add(new TestEntity());
			_testDbContext.TestEntities.Add(new TestEntity());
			_testDbContext.SaveChanges();

			_queryContext = Substitute.ForPartsOf<QueryContext>();
			_queryContext.GetContext().Returns(_testDbContext);

			_queryRepository = Substitute.ForPartsOf<QueryRepository>(_queryContext);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_testDbContext?.Database?.EnsureDeleted();
			_testDbContext?.Dispose();
		}

		[TestMethod]
		public async Task Query_RunAIQueryList_ReturnsIEnumerable()
		{
			//	Assemble
			var query = new TestEntitiesGetAll();

			//	Act
			var result = await _queryRepository.Query(query);

			//	Assert
			Assert.AreEqual(3, result.Count());
		}

		[TestMethod]
		public async Task Query_RunAIQueryScalar_ReturnsInt()
		{
			//	Assemble
			var query = new TestEntitiesCount();

			//	Act
			var result = await _queryRepository.Query(query);

			//	Assert
			Assert.AreEqual(3, result);
		}

		public class TestModel  { }

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

		internal class TestEntitiesGetAll : IQueryList<TestModel>
		{
			public IQueryable<TestModel> Query(IQueryContext context)
			{
				return from te in context.Set<TestEntity>()
					   select new TestModel();
			}
		}

		internal class TestEntitiesCount : IQueryScalar<int>
		{
			public async Task<int> GetScalar(IQueryContext context)
			{
				return await context.Set<TestEntity>().CountAsync();
			}
		}
	}
}
