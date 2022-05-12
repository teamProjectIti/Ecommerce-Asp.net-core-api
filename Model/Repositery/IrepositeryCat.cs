using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Model.Repositery
{
    public interface IrepositeryCat:Ibase
    {
        Task<categore> GetById(int? id);
        Task<IEnumerable<categore>> GetByIDTolist(int? id);
        Task<IEnumerable<categore>> GetAll();
    }
}
