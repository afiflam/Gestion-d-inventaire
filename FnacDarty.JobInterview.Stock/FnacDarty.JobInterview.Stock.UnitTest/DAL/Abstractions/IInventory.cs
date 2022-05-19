using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions
{
    internal interface IInventory
    {
        int InsertInventory(string ean, int quantite, int dateinventory);
        bool IsInventoryExist(string ean);

        int GetDateForInventory(string ean);
    }
}
