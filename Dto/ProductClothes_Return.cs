using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Model;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Dto
{
    public class ProductClothes_Return
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public string PictureUrl { get; set; }
        public double Qount { get; set; }
        public double price_Sall_all { get; set; }//هبيع المنتجات كلهم بالمكسب بكام
        public DateTime Date_attach { get; set; }
        public DateTime Date_Experied { get; set; }
        public double qountity { get; set; }

        public string categore_name { get; set; }
        public string product_brand_name { get; set; }

    }
}
