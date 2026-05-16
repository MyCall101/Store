using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Classes
{
    internal class Item
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public string Grams { get; set; }
        public string Milliliters { get; set; }
        public decimal ItemPrice { get; set; }

        public decimal SellPrice { get; set; }
        public string ItemId { get; set; }

    }
}
