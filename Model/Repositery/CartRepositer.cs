using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model.Dashbord.Cart;

namespace WebApplication1.Model.Repositery
{
    public class CartRepositer : IRepositerCart
    {
        private readonly ApplicationContext context;
        public CartRepositer(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Add<T>(T entity) where T : class
        {
              await context.AddAsync(entity);
            SaveChanges();
         }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CustomerBasket>> GetAll()
        {
            throw new System.NotImplementedException();
        }

         

        public Task<CustomerBasket> GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        
        public async Task<IEnumerable<CustomerBasket>> GetByIDTolist(string data)
        {

            return await context.CustomerBaskets.Where(x => x.email == data).ToListAsync();
        }

        public  int GetByIDTolistConnt(string data)
        {
            return  context.CustomerBaskets.Where(x => x.email == data).Count();
        }
        public bool Check(string data,int id)
        {
            var shopList = context.CustomerBaskets.Where(x => x.email == data && x.IDProduct == id).FirstOrDefault();
            if (shopList == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}
