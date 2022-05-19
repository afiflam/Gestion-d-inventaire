using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Concretes
{
    internal class Stock : IStock
    {
        internal readonly DataContext context;
        public Stock()
        {
            context = DataContext.Instance;
        }


        public int GetCurrentStockByProduct(string ean)
        {
            var stk = context.StockModels.Find(ean);
            return stk == null ? -1 : stk.Quantite;

        }

        public int GetStockForProductByDate(string ean, int datestock)
        {

            List<FluxProductModel> fluxproductmodels = context.FluxProductModels.ToList().Where(p => p.EAN == ean).ToList();
            List<FluxModel> fluxmodels = context.FluxModels.ToList().Where(p => p.DateFlux <= datestock).ToList();
            if (fluxproductmodels.Count == 0 || fluxmodels.Count == 0)
            {
                return 0;
            }
            int compte = 0;
            foreach (var item in fluxproductmodels)
            {
                if (fluxmodels.Select(p => p.FluxID).Contains(item.FluxID))
                {
                    compte += item.Quantite;
                }
            }
            return compte;

        }

        public List<Tuple<string, int, int>> GetCurrentStockProducts()
        {

            List<StockModel> liststocks = context.StockModels.Where(p => p.Quantite > 0).ToList();
            List<Tuple<string, int, int>> output = new List<Tuple<string, int, int>>();
            foreach (StockModel item in liststocks)
            {
                output.Add(new Tuple<string, int, int>(item.EAN, item.DateStock, item.Quantite));
            }
            return output;

        }

        public int GetCurrentStockProductsCount()
        {
            List<StockModel> liststocks = context.StockModels.ToList();
            int prds = liststocks.Count(p => p.Quantite > 0);
            return liststocks.Count() == 0 ? 0 : prds;

        }

        public int GetCurrentStockArticlesCount()
        {
            List<StockModel> liststocks = context.StockModels.ToList();
            int prds = liststocks.Where(p => p.Quantite > 0).Sum(p => p.Quantite);
            return prds;

        }

        public int InsertStock(string ean, int quantite, int datestock)
        {
            context.StockModels.Add(new StockModel() { EAN = ean, Quantite = quantite, DateStock = datestock });
            int result = context.SaveChanges();
            return result;

        }

        public int UpdateStock(string ean, int quantite, int datestock)
        {

            StockModel model = context.StockModels.Find(ean);
            model.Quantite = quantite + model.Quantite;
            model.DateStock = datestock;
            int result = context.SaveChanges();
            return result;

        }
    }
}
