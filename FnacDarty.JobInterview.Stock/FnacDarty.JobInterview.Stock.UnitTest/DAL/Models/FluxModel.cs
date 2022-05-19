using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL.Models
{
    internal class FluxModel
    {
        [Key] 
        public int FluxID { get; set; }
        public int DateFlux { get; set; }
        public string Libelle { get; set; }
        public bool IsInventory { get; set; }

        public ICollection<FluxProductModel> FluxProductModels { get; set; }
    }
}
