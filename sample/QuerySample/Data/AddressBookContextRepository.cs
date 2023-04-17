using myNOC.EntityFramework.Query;

namespace QuerySample.Data
{
	public class AddressBookContextRepository : QueryRepository, IAddressBookContextRepository
	{
		public AddressBookContextRepository(IAddressBookContext context) : base(context)
		{
		}
	}
}
