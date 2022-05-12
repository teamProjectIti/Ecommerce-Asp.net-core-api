using System.Threading.Tasks;

namespace WebApplication1.Model.Repositery
{
    public interface Ibase
    {
        Task Add<T>(T entity) where T : class;
        void update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void SaveChanges();
    }
}
