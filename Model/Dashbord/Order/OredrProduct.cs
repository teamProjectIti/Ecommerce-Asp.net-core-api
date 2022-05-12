using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model.Dashbord.Order
{
    public class OredrProduct
    {
        [Key]
        public int ID { get; set; }
        public string NameProduct { get; set; }
        public string emailUser { get; set; }
        public string image_product { get; set; }
        public int IDProduct { get; set; }
       
        public double Price { get; set; }
        public string descripation { get; set; }
    }
}
