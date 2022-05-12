using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.Dashbord.Order
{
    public class OrderUser
    {
        [Key]
        public int ID { get; set; }
        public int IdProduct { get; set; }
        public string nameProduct { get; set; }
        public double price { get; set; }
        public int count { get; set; }
        public double totalPrice { get; set; }
        public string email { get; set; }
    }
}
