using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class ItemRelationship
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int SubItemId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string UnitPrice { get; set; }
        public string SubItemName { get; set; }
        public decimal Cost { get; set; }
        //public string SelectedType { get; set; }
    }
}