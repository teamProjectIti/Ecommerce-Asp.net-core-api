using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Model.Repositery
{
    public interface IRepositeryBrand:Ibase
    {
        Task<ProductBrand> GetById(int? id);
        Task<IEnumerable<ProductBrand>> GetByIDTolist(int? id);
        Task<IEnumerable<ProductBrand>> GetAll();
    }
}
