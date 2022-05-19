using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Abstractions
{
    internal interface IProduct
    {
        bool IsProductExist(string ean);
        int InsertProduct(string ean);
    }
}
