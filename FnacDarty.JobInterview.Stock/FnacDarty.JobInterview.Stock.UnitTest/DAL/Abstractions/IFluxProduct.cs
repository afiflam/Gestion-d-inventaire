using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions
{
    internal interface IFluxProduct
    {
        int InsertFluxProduct(string ean, int fluxid, int quantite);
    }
}
