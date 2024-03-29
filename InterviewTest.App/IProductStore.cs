﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.App
{
	public interface IProductStore: IEnumerable<IProduct>
    {
		IEnumerable<IProduct> LoadProducts();

		void Add(IProduct product);
		void Remove(Guid productId);

		//Let's assume we cannot update a product
		event Action<IProduct> ProductAdded;
		event Action<Guid> ProductRemoved;
	}
}
