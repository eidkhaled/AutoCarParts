using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarParts.Models
{
    public class Part
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
