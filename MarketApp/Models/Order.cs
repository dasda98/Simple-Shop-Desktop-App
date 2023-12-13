using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketApp.Models
{
    [Table("order", Schema = "shop")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("total_amount")]
        public float TotalAmount { get; set; }

        [ForeignKey("customer_id")]
        public virtual Customer Customer { get; set; }

    }
}
