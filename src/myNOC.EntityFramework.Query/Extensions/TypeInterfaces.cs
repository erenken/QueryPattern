namespace myNOC.EntityFramework.Query.Extensions
{
	public class TypeInterfaces
	{
		public TypeInterfaces(Type type)
		{
			Type = type;
		}

		public Type Type { get; }
		public List<Type> Interfaces { get; set; } = new List<Type>();
	}
}
