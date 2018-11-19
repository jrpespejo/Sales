
namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]       
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name ="Image")]
        public string ImagePath { get; set; }

        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public Decimal Price { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Publish On")]

        [DataType(DataType.Date)]
        public DateTime PublisOn { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
         
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagePath))
                {
                    return "noproduct";
                }
                //return $"https://salesapi1.azurewebsites.net/{this.ImagePath.Substring(1)}";
                return $"http://www.xquinde.somee.com/{this.ImagePath.Substring(1)}";
            }
        }
        public override string ToString()
        {
            return this.Description;
        }

    }
}
