using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model.Repositery;

namespace WebApplication1.Model
{
    public class RepositeryProduct : IRepositeryProduct
    {
        private readonly ApplicationContext _context;

        public RepositeryProduct(ApplicationContext context)
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
            await _context.AddAsync(entity);
            SaveChanges();
        }
        public async Task<IEnumerable<product>> GetAll()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<product> GetById(int? id)
        {
            return await _context.products.Include(x=>x.categores).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<product>> GetByIDTolist(int? id)
        {
            return await _context.products.Where(x => x.ID == id).ToListAsync();
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
