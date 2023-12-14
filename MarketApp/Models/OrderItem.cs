using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Models
{
    [Table("order_items", Schema = "shop")]
    public class OrderItem
    {
        [Key]
        [Column("order_item_id")]
        public int OrderItemId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("order_id")]
        public virtual Order Order { get; set; }

        [ForeignKey("product_id")]
        public virtual Product Product { get; set; }
    }
}
