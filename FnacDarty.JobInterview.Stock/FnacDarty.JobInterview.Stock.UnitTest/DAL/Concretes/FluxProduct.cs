using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Concretes
{
    internal class FluxProduct : IFluxProduct
    {
        internal readonly DataContext context;
        public FluxProduct()
        {
            context = DataContext.Instance;
        }
        public int InsertFluxProduct(string ean, int fluxid, int quantite)
        {

            context.FluxProductModels.Add(new FluxProductModel() { EAN = ean, FluxID = fluxid, Quantite = quantite });
            int result = context.SaveChanges();
            return result;

        }
    }
}
