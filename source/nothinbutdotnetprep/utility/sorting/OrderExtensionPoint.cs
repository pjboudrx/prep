using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.sorting
{
    public class OrderExtensionPoint<ItemToSort> : IEnumerable<ItemToSort>
    {
    	private readonly IEnumerable<ItemToSort> _items;
		private IComparer<ItemToSort> _orderBy;

    	public OrderExtensionPoint()
        {
            
        }

    	public OrderExtensionPoint(IEnumerable<ItemToSort> items)
    	{
    		_items = items;
    	}

		public OrderExtensionPoint<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor, params PropertyType[] values)
    	{
			_orderBy = Order<ItemToSort>.by(accessor, values);
			return this;
    	}

		public OrderExtensionPoint<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
		{
			_orderBy = _orderBy.then_by(accessor);
			return this;
		}

		public List<ItemToSort> to_list()
		{
			var list = new List<ItemToSort>(_items);
			list.Sort(_orderBy);
			return list;
		} 

		public static implicit operator List<ItemToSort>(OrderExtensionPoint<ItemToSort> m)
		{
			return m.to_list();
		}

    	public IEnumerator<ItemToSort> GetEnumerator()
    	{
    		return to_list().GetEnumerator();
    	}

    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return GetEnumerator();
    	}
    }
}