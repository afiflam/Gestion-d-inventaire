using FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions;
using FnacDarty.JobInterview.Stock.UnitTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Concretes
{
    internal class Flux : IFlux
    {
        internal readonly DataContext context;
        public Flux()
        {
            context = DataContext.Instance;
        }

        public int GetFluxId(int dateflux, string libelle, bool isinventory = false)
        {

            List<FluxModel> listflux = context.FluxModels.ToList();
            FluxModel flux = listflux.Find(p => p.IsInventory == isinventory && p.DateFlux == dateflux && p.Libelle == libelle);
            return flux == null ? -1 : flux.FluxID;

        }

        public int InsertFlux(int dateflux, string libelle, bool isinventory = false)
        {
            if (GetFluxId(dateflux, libelle, isinventory) == -1)
            {
                context.FluxModels.Add(new FluxModel() { DateFlux = dateflux, Libelle = libelle, IsInventory = isinventory });
                int result = context.SaveChanges();
                return result;
            }
            return 1;


        }

        public bool IsAutorizedFlux(int dateflux, string ean)
        {

            var invent = context.InventoryModels.Find(ean);
            if (invent == null)
            {
                return true;
            }
            var dat = invent.DateInventory;
            return dateflux > dat;

        }
    }
}
