using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model.Dashbord
{
    public class ProductClothe
    {
        [Key]
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

        [ForeignKey("categores")]
        public int categore_ID { get; set; }
        public virtual categore categores { get; set; }
        [ForeignKey("ProductBrands")]
        public int product_ID_brand { get; set; }
        public virtual ProductBrand ProductBrands { get; set; }
        public virtual ICollection<ProductGallary> productGallary { get; set; }
    }
}
