using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableMatchFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public ComparableMatchFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchA<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousMatch<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
        }

        public IMatchA<ItemToFilter> between(PropertyType start,PropertyType end)
        {
			return new AnonymousMatch<ItemToFilter>(x =>
			                                        {
			                                        	var actual = accessor(x);
			                                        	return actual.CompareTo(start) >= 0 && actual.CompareTo(end) < 0;
			                                        });
        }
    }
}