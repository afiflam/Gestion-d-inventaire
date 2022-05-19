using System;
using System.Collections.Generic;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Models
{
    internal class FluxProductModel
    {
        public string EAN { get; set; }
        public int FluxID { get; set; }
        public int Quantite { get; set; }
        public ProductModel ProductModel { get; set; }
        public FluxModel FluxModel { get; set; }
    }
}
