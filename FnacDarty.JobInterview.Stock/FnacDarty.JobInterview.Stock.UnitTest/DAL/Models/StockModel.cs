using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Models
{
    internal class StockModel
    {
        [Key]
        public string EAN { get; set; }
        public int Quantite { get; set; }
        public int DateStock { get; set; }

        public ProductModel ProductModel { get; set; }
    }
}
