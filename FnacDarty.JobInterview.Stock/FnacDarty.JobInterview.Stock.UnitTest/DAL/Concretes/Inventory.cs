using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Concretes
{
    internal class Inventory : IInventory
    {

        internal readonly DataContext context;
        public Inventory()
        {
            context = DataContext.Instance;
        }

        public int GetDateForInventory(string ean)
        {

            InventoryModel invent = context.InventoryModels.Find(ean);
            return invent == null ? -1 : invent.DateInventory;

        }

        public int InsertInventory(string ean, int quantite, int dateinventory)
        {
            context.InventoryModels.Add(new InventoryModel() { EAN = ean, Quantite = quantite, DateInventory = dateinventory });
            int result = context.SaveChanges();
            return result;

        }

        public bool IsInventoryExist(string ean)
        {

            var result = context.InventoryModels.Find(ean);
            return result != null;

        }
    }
}
