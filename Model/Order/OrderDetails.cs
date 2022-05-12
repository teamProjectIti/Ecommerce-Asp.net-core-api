using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Model.Order
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeaders { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductClothe ProductClothe { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
    }
}
