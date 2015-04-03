using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public string Brand { get; set; }
        public string Tags { get; set; }
        public double WholesalePrice { get; set; }
        public double RetailPrice { get; set; }
        public double BuyPrice { get; set; }
        public double InitialCostPrice { get; set; }
        public int Stock { get; set; }
        public Boolean Taxable { get; set; }
        public Boolean ManageStock { get; set; }
        public Boolean KeepSelling { get; set; }
        public Boolean PublishOnline { get; set; }
        public Boolean OnlineOrdering { get; set; }
        public int ClientId { get; set; }
        
    }
}