using Microsoft.EntityFrameworkCore;
using myNOC.EntityFramework.Query;

namespace QuerySample.Data
{
	public class AddressBookContext : QueryContext, IAddressBookContext
	{
		private DbContext? _dbContext = null;
		public override DbContext GetContext()
		{
			if (_dbContext == null)
				_dbContext = new AddressBookDbContext();

			return _dbContext;
		}
	}
}
