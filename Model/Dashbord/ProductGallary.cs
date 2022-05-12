using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model.Dashbord
{
    public class ProductGallary
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int productId { get; set; }
        [ForeignKey("productId")]
        public virtual ProductClothe productClothes { get; set; }
    }
}
