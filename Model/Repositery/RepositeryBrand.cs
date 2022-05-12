using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Model.Repositery
{
    public class RepositeryBrand:IRepositeryBrand
    {

        private readonly ApplicationContext _context;

        public RepositeryBrand(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Add<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
            SaveChanges();
        }

        public   void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
            SaveChanges();
        }
        public async Task<IEnumerable<ProductBrand>> GetAll()
        {
            return await _context.ProductBrands.Include(x => x.ProductClothe).ToListAsync();
        }
        public async Task<ProductBrand> GetById(int? id)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<IEnumerable<ProductBrand>> GetByIDTolist(int? id)
        {
            return await _context.ProductBrands.Where(x => x.ID == id).ToListAsync();
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
