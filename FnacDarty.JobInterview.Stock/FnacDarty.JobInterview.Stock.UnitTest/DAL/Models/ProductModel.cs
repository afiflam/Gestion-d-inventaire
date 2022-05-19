using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Models
{
    internal class ProductModel
    {
        [Key]
        public string EAN { get; set; }
        public ICollection<FluxProductModel> FluxProductModels { get; set; }
    }
}
