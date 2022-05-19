using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Concretes
{
    internal class Product : IProduct
    {
        internal readonly DataContext context;
        public Product()
        {
            context = DataContext.Instance;
        }
        public int InsertProduct(string ean)
        {
            context.ProductModels.Add(new ProductModel() { EAN = ean });
            int result = context.SaveChanges();
            return result;

        }

        public bool IsProductExist(string ean)
        {
            var result = context.ProductModels.Find(ean);
            return result != null;

        }
    }
}
