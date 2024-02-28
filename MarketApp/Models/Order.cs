using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public float TotalAmount { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
