using System;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Dto
{
    public class cartShopDto
    {
        public int IDProduct { get; set; }
        public string Image { get; set; }
        public string Name_product { get; set; }
        public string descripation { get; set; }
        public string Price { get; set; }
        public string emailUser { get; set; }
    }
}
