

using FnacDarty.JobInterview.Stock.Interfaces;
using System;
using System.Collections.Generic;

namespace FnacDarty.JobInterview.Stock
{
    public class Stocks : IStocks
    {
        public int GetAllArticleInStockCount(Func<int> GetCurrentStockArticlesCount)
        {
            int result = GetCurrentStockArticlesCount();

            return result;
        }

        public int GetAllProductInStockCount(Func<int> GetCurrentStockProductsCount)
        {
            int result = GetCurrentStockProductsCount();

            return result;
        }

        public List<Tuple<string, string, int>> GetCurrentStockContent(Func<List<Tuple<string, int, int>>> GetCurrentStockProducts)
        {
            var result = GetCurrentStockProducts();
            List<Tuple<string, string, int>> output = new List<Tuple<string, string, int>>();
            foreach (Tuple<string, int, int> item in result)
            {
                int dat = item.Item2;
                Tuple<string, string, int> t = new Tuple<string, string, int>(dat.FormatFnacDateInteger(), item.Item1, item.Item3);
                output.Add(t);
            }

            return output;
        }

        public int GetCurrentStockForProduct(string ean, Func<string, int> GetCurrentStockByProduct)
        { 
            if ( !ean.IsValidEAN())
            {
                throw new Exception();
            }
            int result = GetCurrentStockByProduct(ean);

            return result;
        }

        public int GetStockForProductByDate(string ean, DateTime dateflux, Func<string, int, int> GetStockForProductByDate)
        {
            int dateFluxInteger = dateflux.ConvertToFnacDateInteger();
            if (!dateFluxInteger.IsValidFnacDateInteger() || !ean.IsValidEAN()  )
            {
                throw new Exception();
            }
            int result = GetStockForProductByDate(ean, dateFluxInteger);

            return result;
        }

        public int GetVariationOfStockForProductBetweenTwoDates(string ean, DateTime dateflux1, DateTime dateflux2, Func<string, int, int> GetStockForProductByDate)
        {
            int dateFluxInteger1 = dateflux1.ConvertToFnacDateInteger();
            int dateFluxInteger2 = dateflux2.ConvertToFnacDateInteger();
            if (!dateFluxInteger1.IsValidFnacDateInteger() || !dateFluxInteger2.IsValidFnacDateInteger() || !ean.IsValidEAN())
            {
                throw new Exception();
            }
            int result1 = GetStockForProductByDate(ean, dateFluxInteger1);
            int result2 = GetStockForProductByDate(ean, dateFluxInteger2);

            return result2 - result1;
        }
    }
}
