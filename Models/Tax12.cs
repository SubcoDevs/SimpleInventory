using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{

    [Table("Tax12")]
    public class Tax12
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public double TaxRate { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        
    }
}