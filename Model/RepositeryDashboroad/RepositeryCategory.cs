using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Model.RepositeryDashboroad
{
    public class RepositeryCategory:IRepositeryCategory
    {
        private readonly ApplicationContext _context;

        public RepositeryCategory(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Add<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
            SaveChanges();
        }
        public async void Delete<T>(T entity) where T : class
        {
              _context.Remove(entity);
            SaveChanges();
        }
        public async Task<IEnumerable<categore>> GetAll()
        {
            return await _context.categores.ToListAsync();
        }

        public async Task<categore> GetById(int? id)
        {
            return await _context.categores.FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<IEnumerable<categore>> GetByIDTolist(int? id)
        {
            return await _context.categores.Where(x => x.ID == id).ToListAsync();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void update<T>(T entity) where T : class
        {
            _context.Update(entity);
            SaveChanges();
        }
    }
}

