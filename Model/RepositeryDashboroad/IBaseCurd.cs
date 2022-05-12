using System.Threading.Tasks;

namespace WebApplication1.Model.RepositeryDashboroad
{
    public interface IBaseCurd
    {
        Task Add<T>(T entity) where T : class;
        void update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void SaveChanges();
    }
}
