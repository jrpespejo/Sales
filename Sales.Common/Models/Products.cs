
namespace Sales.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime PublisOn { get; set; }
        public override string ToString()
        {
            return this.Description;
        }

    }
}
