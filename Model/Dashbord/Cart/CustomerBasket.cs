using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model.Dashbord.Cart
{
    public class CustomerBasket
    {
        [Key]
        public int ID { get; set; }
        public string email { get; set; }
        public int IDProduct { get; set; }
        [NotMapped]
        [ForeignKey("IDProduct")]
        public virtual ProductClothe ProductClothes { get; set; }

        public int count { get; set; }
        public double PriceTotal { get; set; }
        //  public double PriceTotalAllProduct { get; set; }
        public double Price { get; set; }
    }
}
