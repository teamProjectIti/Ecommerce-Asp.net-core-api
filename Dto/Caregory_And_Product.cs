using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class Caregory_And_Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product_Details> product { get; set; } = new List<Product_Details>();
    }
}
