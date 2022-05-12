using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Model.Repositery
{
    public interface IRepositeryProduct:Ibase
    {
        Task<product> GetById(int? id);
        Task<IEnumerable<product>> GetByIDTolist(int? id);
        Task<IEnumerable<product>> GetAll();
    }
}
