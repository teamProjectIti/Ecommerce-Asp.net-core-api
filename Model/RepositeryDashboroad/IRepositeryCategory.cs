using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Model.RepositeryDashboroad
{
    public interface IRepositeryCategory:IBaseCurd
    {
        Task<categore> GetById(int? id);
        Task<IEnumerable<categore>> GetByIDTolist(int? id);
        Task<IEnumerable<categore>> GetAll();
    }
}
