using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesShop.Models
{   /// <summary>
   /// This class gets called when "Catalog" section is selected. 
  /// </summary>
    public class Catalog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string Colour { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
