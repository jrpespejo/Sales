
namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }       

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagePath))
                {
                    return "noproduct";
                }

                //return $"https://salesbackend20181015104409.azurewebsites.net{this.ImagePath.Substring(1)}";
                return $"http://www.xquinde.somee.com{this.ImagePath.Substring(1)}";
            }
        }

        [JsonIgnore]
        public virtual ICollection<Products> Products { get; set; }

    }
}
