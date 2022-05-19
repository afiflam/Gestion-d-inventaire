using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using FnacDarty.JobInterview.Stock.UnitTest.DAL;
using Microsoft.EntityFrameworkCore;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Concretes;
using System;

namespace FnacDarty.JobInterview.Stock.UnitTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]

        public void CheckConnectivity()
        {
            try
            {
                DataContext.Instance.Database.EnsureCreated();

            }
            catch (System.Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void InsertFlux()
        {
            IFlux flux = new Flux();
            int dateflux = new DateTime(2022, 5, 11).ConvertToFnacDateInteger();
            string libelle = "achat";
            bool isinventory = false;


            int result = flux.InsertFlux(dateflux, libelle, isinventory);

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void GetFluxId()
        {
            IFlux flux = new Flux();
            int dateflux = new DateTime(2022, 5, 11).ConvertToFnacDateInteger();
            string libelle = "achat";
            bool isinventory = false;


            int result = flux.GetFluxId(dateflux, libelle, isinventory);

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void GetDateForInventory()
        {
            IInventory inventory = new Inventory();
            string ean = "ean00001";
            int result = inventory.GetDateForInventory(ean);

            Assert.IsTrue(result > -1);
        }

        //GetDateForInventory

        [TestMethod]
        public void IsAutorizedFlux()
        {
            IFlux flux = new Flux();
            int dateflux = 20220519;
            string ean = "ean00001";

            bool result = flux.IsAutorizedFlux(dateflux, ean);
        }


        [TestMethod]
        public void InsertFluxProduct()
        {
            IFluxProduct fluxproduct = new FluxProduct();
            int quantite = 556;
            int fluxid = 11;
            string ean = "ean00001";

            int result = fluxproduct.InsertFluxProduct(ean, fluxid, quantite);

            Assert.IsTrue(result > -1);

        }
        [TestMethod]
        public void InsertInventory()
        {
            IInventory inventory = new Inventory();
            int quantite = 12;
            int dateinventory = new DateTime(2022, 3, 25).ConvertToFnacDateInteger();
            string ean = "ean00001";

            int result = inventory.InsertInventory(ean, quantite, dateinventory);

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void IsInventoryExist()
        {
            IInventory inventory = new Inventory();
            string ean = "ean00001";

            bool result = inventory.IsInventoryExist(ean);

        }

        [TestMethod]
        public void IsProductExist()
        {
            IProduct product = new Product();
            string ean = "ean00001";

            bool result = product.IsProductExist(ean);

        }

        [TestMethod]
        public void InsertProduct()
        {
            IProduct product = new Product();
            string ean = "ean00001";

            int result = product.InsertProduct(ean);

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void InsertStock()
        {
            IStock stock = new DAL.Concretes.Stock();
            int quantite = 55555;
            int datestock = new DateTime(2022, 6, 5).ConvertToFnacDateInteger();
            string ean = "ean00001";

            int result = stock.InsertStock(ean, quantite, datestock);

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void UpdateStock()
        {
            IStock stock = new DAL.Concretes.Stock();
            int quantite = 556;
            int datestock = 20221105;
            string ean = "ean00001";

            int result = stock.UpdateStock(ean, quantite, datestock);

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void GetCurrentStockByProduct()
        {
            IStock stock = new DAL.Concretes.Stock();
            string ean = "ean00002";

            int result = stock.GetCurrentStockByProduct(ean);
        }

        [TestMethod]
        public void GetStockForProductByDate()
        {
            IStock stock = new DAL.Concretes.Stock();
            string ean = "ean00001";
            int datestock = 20220512;

            int result = stock.GetStockForProductByDate(ean, datestock);
        }

        [TestMethod]
        public void GetCurrentStockProducts()
        {
            IStock stock = new DAL.Concretes.Stock();

            var result = stock.GetCurrentStockProducts();
        }

        [TestMethod]
        public void GetCurrentStockProductsCount()
        {
            IStock stock = new DAL.Concretes.Stock();

            var result = stock.GetCurrentStockProductsCount();
            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void GetCurrentStockArticlesCount()
        {
            IStock stock = new DAL.Concretes.Stock();

            var result = stock.GetCurrentStockArticlesCount();
            Assert.IsTrue(result > -1);
        }


    }
}
