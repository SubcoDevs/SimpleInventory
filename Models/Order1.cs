using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Order1
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int SubproductId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime OrderDispatchDate { get; set; }

        public DateTime OrderRequestDate { get; set; }

        public DateTime OrderShipmentDate { get; set; }

        public double Rate { get; set; }
        public double TotalPrice { get; set; }

        public int Quantity { get; set; }

    }
}