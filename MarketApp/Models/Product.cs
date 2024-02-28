using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public float UnitPrice { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
