using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Dashbord;
using WebApplication1.Model.ViewModel;

namespace WebApplication1.Model.RepositeryDashboroad
{
    public interface IRepositeryProductClotes :IBaseCurd
    {
        Task Add_entity(ProductViewModel entity);//
        Task<ProductClothe> GetById(int? id);
        Task<IEnumerable<ProductClothe>> GetByIDTolist(int? id);
        Task<IEnumerable<ProductGallary>> GetByIDTolistImg(int? id);
        Task<IEnumerable<ProductClothe>> GetAll();
    }
}
