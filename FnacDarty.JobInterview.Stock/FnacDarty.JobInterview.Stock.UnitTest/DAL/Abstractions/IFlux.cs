using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions
{
    internal interface IFlux
    {
        int GetFluxId(int dateflux, string libelle, bool isinventory = false);
        int InsertFlux(int dateflux,string libelle,bool isinventory=false);
        bool IsAutorizedFlux(int dateflux, string ean);
    }
}
