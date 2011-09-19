namespace nothinbutdotnetprep.utility.filtering
{
	public class NotMatch<Item>:IMatchA<Item>
	{
		private readonly IMatchA<Item> _inner;

		public NotMatch(IMatchA<Item> inner)
		{
			_inner = inner;
		}

		public bool matches(Item item)
		{
			return !_inner.matches(item);
		}
	}
}