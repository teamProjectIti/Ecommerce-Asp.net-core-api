using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Model.Dashbord.Cart;

namespace WebApplication1.Model.Repositery
{
    public interface IRepositerCart:Ibase
    {
        Task<CustomerBasket> GetById(int? id);
        Task<IEnumerable<CustomerBasket>> GetByIDTolist(string data);
        int GetByIDTolistConnt(string data);
        Task<IEnumerable<CustomerBasket>> GetAll();
        bool Check(string data, int id);
    }
}
