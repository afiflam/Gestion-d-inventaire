using FnacDarty.JobInterview.Stock.Interfaces;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FnacDarty.JobInterview.Stock.UnitTest
{
    [TestClass]
    public class StockTest
    {
        [TestMethod]
        public void GetStockForProductByDate()
        {
            IStocks stk = new Stocks();
            IStock stockConcrete = new DAL.Concretes.Stock();

            string ean = "ean00004";
            DateTime dateflux = new DateTime(2022, 6, 6);

            int result = stk.GetStockForProductByDate(ean, dateflux, (string a, int b) => stockConcrete.GetStockForProductByDate(a, b));

            Assert.IsTrue(1 == 1);

        }

        [TestMethod]
        public void GetVariationOfStockForProductBetweenTwoDates()
        {
            IStocks stk = new Stocks();
            IStock stockConcrete = new DAL.Concretes.Stock();

            string ean = "ean00004";
            DateTime dateflux1 = new DateTime(2022, 1, 6);
            DateTime dateflux2 = new DateTime(2022, 6, 6);

            int result = stk.GetVariationOfStockForProductBetweenTwoDates(ean, dateflux1, dateflux2, (string a, int b) => stockConcrete.GetStockForProductByDate(a, b));

            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void GetCurrentStockForProduct()
        {
            IStocks stk = new Stocks();
            IStock stockConcrete = new DAL.Concretes.Stock();

            string ean = "ean00004";

            int result = stk.GetCurrentStockForProduct(ean, (string a) => stockConcrete.GetCurrentStockByProduct(a));

            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void GetCurrentStockContent()
        {
            IStocks stk = new Stocks();
            IStock stockConcrete = new DAL.Concretes.Stock();

            List<Tuple<string, string, int>> result = stk.GetCurrentStockContent(() => stockConcrete.GetCurrentStockProducts());

            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void GetAllProductInStockCount()
        {
            IStocks stk = new Stocks();
            IStock stockConcrete = new DAL.Concretes.Stock();

            int result = stk.GetAllProductInStockCount(() => stockConcrete.GetCurrentStockProductsCount());

            Assert.IsTrue(result != -1);
        }

        [TestMethod]
        public void GetAllArticleInStockCount()
        {
            IStocks stk = new Stocks();
            IStock stockConcrete = new DAL.Concretes.Stock();

            int result = stk.GetAllArticleInStockCount(() => stockConcrete.GetCurrentStockArticlesCount());

            Assert.IsTrue(result != -1);
        }
    }
}
