using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Model.Dashbord
{
    public class ProductBrand
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductClothe> ProductClothe { get; set; }
    }
}
