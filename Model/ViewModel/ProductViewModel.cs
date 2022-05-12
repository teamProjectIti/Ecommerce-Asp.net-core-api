using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Model.ViewModel
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public IFormFile PictureUrl { get; set; }
        public string ConvertPictureUrl { get; set; }
        public double qountity { get; set; }
        public DateTime Date_attach { get; set; }
        public DateTime Date_Experied { get; set; }
        public int categore_ID { get; set; }
        public int product_ID_brand { get; set; }
        public IFormFileCollection picturGallaryFils { get; set; }
        public List<gallaryModel> Gallery { get; set; }
    }
}
