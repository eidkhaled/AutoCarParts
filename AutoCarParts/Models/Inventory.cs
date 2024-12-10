using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarParts.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime LastUpdated { get; set; }
    }

}
