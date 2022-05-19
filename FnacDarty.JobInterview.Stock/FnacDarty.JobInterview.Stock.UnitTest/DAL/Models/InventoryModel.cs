using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Models
{
    internal class InventoryModel
    {
        [Key]
        public string EAN { get; set; }
        public int Quantite { get; set; }
        public int DateInventory { get; set; }
        public ProductModel ProductModel { get; set; }
    }
}
