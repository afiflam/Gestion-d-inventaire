using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.Interfaces
{
    public interface IStocks
    {
        int GetStockForProductByDate(string ean, 
                                     DateTime dateflux, 
                                     Func<string, int,int> GetStockForProductByDate);

        int GetVariationOfStockForProductBetweenTwoDates(string ean,
                                                         DateTime dateflux1,
                                                         DateTime dateflux2,
                                                         Func<string, int, int> GetStockForProductByDate);

        int GetCurrentStockForProduct(string ean, Func<string, int> GetCurrentStockByProduct);

        List<Tuple<string, string, int>> GetCurrentStockContent(Func<List<Tuple<string, int, int>>> GetCurrentStockProducts);

        int GetAllProductInStockCount(Func< int> GetCurrentStockProductsCount);

        int GetAllArticleInStockCount(Func<int> GetCurrentStockArticlesCount);
         



    }
}
