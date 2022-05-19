using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.Interfaces
{
    public interface IProduit
    {
        int AddOrRemoveQuantityForProduct(string ean,
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
                                          Func<string, int, int, int> UpdateStock);
        


        int AddMultipleFluxForMultipleProducts(DateTime dateflux,
                                               string libelle,
                                               List<Tuple<string,int>> eanwithquantity,
                                               Func<string, bool> IsProductExist,
                                               Func<string, int> InsertProduct,
                                               Func<int, string, bool, int> InsertFlux,
                                               Func<int, string, bool, int> GetFluxId,
                                               Func<string, int, int, int> InsertFluxProduct,
                                               Func<string, int, int, int> InsertStock,
                                               Func<int, string, bool> IsAutorizedFlux,
                                               Func<string, int, int, int> UpdateStock);


        int AddInventoryForProduct         (string ean,
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
                                           );
         

    }
}
