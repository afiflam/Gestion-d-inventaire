using System;
using System.Collections.Generic;
using System.Text;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using FnacDarty.JobInterview.Stock.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Concretes;

namespace FnacDarty.JobInterview.Stock.UnitTest
{
    [TestClass]
    public class ProduitTest
    {
        [TestMethod]
        public void AddOrRemoveQuantityForProduct()
        {
            IProduit product = new Produit();
            IProduct proConcrete = new Product();
            IFlux fluxConcrete = new Flux();
            IFluxProduct fluxproductConcrete = new FluxProduct();
            IStock stockConcrete = new DAL.Concretes.Stock();

            string ean = "ean00004";
            string libelle = "vente prod4";
            DateTime dateflux = new DateTime(2022, 6, 6);
            int quantity = -30;

            int result = product.AddOrRemoveQuantityForProduct(ean, quantity, dateflux, libelle,
                                                              (string a) => proConcrete.IsProductExist(a),
                                                              (string a) => proConcrete.InsertProduct(a),
                                                              (int a, string b, bool c) => fluxConcrete.InsertFlux(a, b, c),
                                                              (int a, string b, bool c) => fluxConcrete.GetFluxId(a, b, c),
                                                              (string a, int b, int c) => fluxproductConcrete.InsertFluxProduct(a, b, c),
                                                              (string a, int b, int c) => stockConcrete.InsertStock(a, b, c),
                                                              (int a, string b) => fluxConcrete.IsAutorizedFlux(a, b),
                                                               (string a, int b, int c) => stockConcrete.UpdateStock(a, b, c));

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void AddMultipleFluxForMultipleProducts()
        {
            IProduit product = new Produit();
            IProduct proConcrete = new Product();
            IFlux fluxConcrete = new Flux();
            IFluxProduct fluxproductConcrete = new FluxProduct();
            IStock stockConcrete = new DAL.Concretes.Stock();

            string libelle = "check";
            DateTime dateflux = new DateTime(2022, 7, 7);

            Tuple<string, int> t1 = new Tuple<string, int>("ean00008", 55);
            Tuple<string, int> t2 = new Tuple<string, int>("ean00009", 66);
            Tuple<string, int> t3 = new Tuple<string, int>("ean00010", 77);
            List<Tuple<string, int>> eanwithquantity = new List<Tuple<string, int>>();
            eanwithquantity.Add(t1);
            eanwithquantity.Add(t2);
            eanwithquantity.Add(t3);




            int result = product.AddMultipleFluxForMultipleProducts(dateflux, libelle, eanwithquantity,
                                                               (string a) => proConcrete.IsProductExist(a),
                                                              (string a) => proConcrete.InsertProduct(a),
                                                              (int a, string b, bool c) => fluxConcrete.InsertFlux(a, b, c),
                                                              (int a, string b, bool c) => fluxConcrete.GetFluxId(a, b, c),
                                                              (string a, int b, int c) => fluxproductConcrete.InsertFluxProduct(a, b, c),
                                                              (string a, int b, int c) => stockConcrete.InsertStock(a, b, c),
                                                              (int a, string b) => fluxConcrete.IsAutorizedFlux(a, b),
                                                               (string a, int b, int c) => stockConcrete.UpdateStock(a, b, c));

            Assert.IsTrue(result > -1);
        }

        [TestMethod]
        public void AddInventoryForProduct()
        {
            IProduit product = new Produit();
            IProduct proConcrete = new Product();
            IFlux fluxConcrete = new Flux();
            IFluxProduct fluxproductConcrete = new FluxProduct();
            IStock stockConcrete = new DAL.Concretes.Stock();
            IInventory inventoryConcrete = new Inventory();

            string ean = "ean00004";
            string libelle = "inventaire";
            DateTime dateflux = new DateTime(2022, 8, 6);
            int quantity = 30;

            int result = product.AddInventoryForProduct(ean, quantity, dateflux, libelle,
                                                              (string a) => inventoryConcrete.IsInventoryExist(a),
                                                              (string a, int b, int c) => inventoryConcrete.InsertInventory(a, b, c),
                                                               (string a) => proConcrete.IsProductExist(a),
                                                              (string a) => proConcrete.InsertProduct(a),
                                                              (int a, string b, bool c) => fluxConcrete.InsertFlux(a, b, c),
                                                              (int a, string b, bool c) => fluxConcrete.GetFluxId(a, b, c),
                                                              (string a, int b, int c) => fluxproductConcrete.InsertFluxProduct(a, b, c),
                                                              (string a, int b, int c) => stockConcrete.InsertStock(a, b, c),
                                                              (int a, string b) => fluxConcrete.IsAutorizedFlux(a, b),
                                                               (string a, int b, int c) => stockConcrete.UpdateStock(a, b, c),
                                                                 (string a) => stockConcrete.GetCurrentStockByProduct(a)
                                                               );

            Assert.IsTrue(result > -1);
        }
    }
}
