using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public virtual Manufacturer? Manufacturer { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]

        public Category? Category { get; set; }
    }
}
