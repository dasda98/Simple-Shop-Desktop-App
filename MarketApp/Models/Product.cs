using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketApp.Models
{
    [Table("product", Schema = "shop")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        
    }
}
