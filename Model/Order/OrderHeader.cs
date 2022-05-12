using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.Order
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Comments { get; set; }
        public DateTime OrderDate { get; set; }
        public int ServicesOrder { get; set; }
        public double  totalPrice { get; set; }
        public double  count { get; set; }


    }
}
