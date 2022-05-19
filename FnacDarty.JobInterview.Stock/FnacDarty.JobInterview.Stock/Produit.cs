using FnacDarty.JobInterview.Stock.Interfaces;
using System;
using System.Collections.Generic;

namespace FnacDarty.JobInterview.Stock
{
    public class Produit : IProduit
    {
        public int AddInventoryForProduct(string ean,
                                           int quantity,
                                           DateTime dateflux,
                                           string libelle,
                                           Func<string, bool> IsInventoryExist,
                                           Func<string, int, int, int> InsertInventory,
                                           Func<string, bool> IsProductExist,
                                           Func<string, int> InsertProduct,
                                           Func<int, string, bool, int> InsertFlux,
                                           Func<int, string, bool, int> GetFluxId,
                                           Func<string, int, int, int> InsertFluxProduct,
                                           Func<string, int, int, int> InsertStock,
                                           Func<int, string, bool> IsAutorizedFlux,
                                           Func<string, int, int, int> UpdateStock,
                                           Func<string, int> GetCurrentStockByProduct
                                           ){

            int dateFluxInteger = dateflux.ConvertToFnacDateInteger();
            if (!dateFluxInteger.IsValidFnacDateInteger() || !ean.IsValidEAN() || quantity <= 0 || IsInventoryExist(ean))
            {
                return -1;
            }
            bool isProductExist = IsProductExist(ean);
            if (!isProductExist)
            {
                AddOrRemoveQuantityForProduct(ean, quantity, dateflux, libelle, IsProductExist, InsertProduct, InsertFlux, GetFluxId, InsertFluxProduct, InsertStock, IsAutorizedFlux, UpdateStock);
            }
            int inventaireCreated = InsertInventory(ean, quantity, dateFluxInteger);
            if (inventaireCreated == -1) return -1;
            int currentStock = GetCurrentStockByProduct(ean);
            int fluxIndex = InsertFlux(dateFluxInteger, libelle, true);
            if (fluxIndex == -1) return -1;
            int fluxId = GetFluxId(dateFluxInteger, libelle, true);
            if (fluxId == -1) return -1;
            int fluxprodIndex = InsertFluxProduct(ean, fluxId, quantity- currentStock);
            if (fluxprodIndex == -1) return -1;

            return 1;
        }

        

        public int AddMultipleFluxForMultipleProducts(DateTime dateflux,
                                                       string libelle,
                                                       List<Tuple<string, int>> eanwithquantity,
                                                       Func<string, bool> IsProductExist,
                                                       Func<string, int> InsertProduct,
                                                       Func<int, string, bool, int> InsertFlux,
                                                       Func<int, string, bool, int> GetFluxId,
                                                       Func<string, int, int, int> InsertFluxProduct,
                                                       Func<string, int, int, int> InsertStock,
                                                       Func<int, string, bool> IsAutorizedFlux,
                                                       Func<string, int, int, int> UpdateStock) {

            int dateFluxInteger = dateflux.ConvertToFnacDateInteger();
            if (!dateFluxInteger.IsValidFnacDateInteger() )
            {
                return -1;
            }
            foreach (Tuple<string, int> item in eanwithquantity)
            {
                string ean = item.Item1;
                if (!ean.IsValidEAN() || !IsAutorizedFlux(dateFluxInteger, ean)) { return -1; }
            }
            foreach (Tuple<string, int> item in eanwithquantity)
            {
                string ean = item.Item1;
                int quantity = item.Item2;
                int result = AddOrRemoveQuantityForProduct(ean, quantity, dateflux, libelle, IsProductExist, InsertProduct, InsertFlux, GetFluxId, InsertFluxProduct, InsertStock, IsAutorizedFlux, UpdateStock);
                if(result == -1) return -1;
            }


            return 1;
        }

        
        public int AddOrRemoveQuantityForProduct(string ean,
                                                  int quantity,
                                                  DateTime dateflux,
                                                  string libelle,
                                                  Func<string, bool> IsProductExist,
                                                  Func<string, int> InsertProduct,
                                                  Func<int, string, bool, int> InsertFlux,
                                                  Func<int, string, bool, int> GetFluxId,
                                                  Func<string, int, int, int> InsertFluxProduct,
                                                  Func<string, int, int, int> InsertStock,
                                                  Func<int, string, bool> IsAutorizedFlux,
                                                  Func<string, int, int, int> UpdateStock) {

            int dateFluxInteger = dateflux.ConvertToFnacDateInteger();
            if (!dateFluxInteger.IsValidFnacDateInteger() || !ean.IsValidEAN())
            {
                return -1;
            }
            bool isProductExist = IsProductExist(ean);
            if (isProductExist)
            {
                bool isAutorizedFlux = IsAutorizedFlux(dateFluxInteger, ean);
                if (!isAutorizedFlux) return 0;
            }
            else
            {
                int insert = InsertProduct(ean);
                if (insert == -1) return -1;
            }

            int fluxIndex = InsertFlux(dateFluxInteger, libelle, false);
            if (fluxIndex == -1) return -1;
            int fluxId = GetFluxId(dateFluxInteger, libelle, false);
            if (fluxId == -1) return -1;
            int fluxprodIndex = InsertFluxProduct(ean, fluxId, quantity);
            if (fluxprodIndex == -1) return -1;
            int stockIndex = isProductExist? UpdateStock(ean, quantity, dateFluxInteger):
                                             InsertStock(ean, quantity, dateFluxInteger);

            if (stockIndex == -1) return -1;

            return 1;
        }
    }
}
