using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class product
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public double price { get; set; }
        public double qountity { get; set; }
        public string Image { get; set; }

        [ForeignKey("categores")]
        public int categore_ID { get; set; }
        public virtual categore categores { get; set; }
    }
}
