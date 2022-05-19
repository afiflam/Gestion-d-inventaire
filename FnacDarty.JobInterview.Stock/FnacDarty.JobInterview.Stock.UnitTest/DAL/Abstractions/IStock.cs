using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions
{
    internal interface IStock
    {
        int InsertStock(string ean, int quantite, int datestock);

        int UpdateStock(string ean, int quantite, int datestock);
        int GetCurrentStockByProduct(string ean);
        int GetStockForProductByDate(string ean,int datestock);

        List<Tuple<string,int,int>> GetCurrentStockProducts();
        int GetCurrentStockProductsCount();
        int GetCurrentStockArticlesCount();
    }
}
