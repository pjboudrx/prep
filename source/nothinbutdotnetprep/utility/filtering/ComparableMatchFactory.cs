﻿using System;

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

		public IMatchA<ItemToFilter> greater_than_equal(PropertyType value)
		{
			return new AnonymousMatch<ItemToFilter>(x => accessor(x).CompareTo(value) >= 0);
		}

		public IMatchA<ItemToFilter> less_than(PropertyType value)
		{
			return new AnonymousMatch<ItemToFilter>(x => accessor(x).CompareTo(value) < 0);
		}

		public IMatchA<ItemToFilter> less_than_equal(PropertyType value)
		{
			return new AnonymousMatch<ItemToFilter>(x => accessor(x).CompareTo(value) <= 0);
		}

        public IMatchA<ItemToFilter> between(PropertyType start,PropertyType end)
        {
        	return greater_than_equal(start).and(less_than_equal(end));
        }
    }
}