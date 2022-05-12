using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model.Dashbord;
using WebApplication1.Model.ViewModel;

namespace WebApplication1.Model.RepositeryDashboroad
{
    public class RepositeryProductClothes:IRepositeryProductClotes
    {
        private readonly ApplicationContext _context;

        public RepositeryProductClothes(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Add_entity (ProductViewModel entity)  
        {
            ProductClothe productClothe = new ProductClothe()
            {
                Name = entity.Name,
                qountity = entity.qountity,
                Price = entity.Price,
                categore_ID = entity.categore_ID,
                product_ID_brand = entity.product_ID_brand,
                Description = entity.Description,
                Date_attach = entity.Date_attach,
                Date_Experied = entity.Date_Experied,
                PictureUrl = entity.ConvertPictureUrl,

            };

             if (entity.Gallery != null)
            {
                productClothe.productGallary = new List<ProductGallary>();
                foreach (var item in entity.Gallery)
                {
                    productClothe.productGallary.Add(new ProductGallary()
                    {
                        Name = item.Name,
                        Url = item.Url
                    });
                }
            }
            await _context.ProductClothes.AddAsync(productClothe);
            SaveChanges();
        }

        public Task Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public async void Delete<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
            SaveChanges();
        }
        public async Task<IEnumerable<ProductClothe>> GetAll()
        {
            var data=await _context.ProductClothes.Include(x => x.categores).Include(x => x.ProductBrands).ToListAsync();
            return data;
        }
        public async Task<ProductClothe> GetById(int? id)
        {
            return await _context.ProductClothes.Include(x => x.categores).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<ProductClothe>> GetByIDTolist(int? id)
        {
            return await _context.ProductClothes.Include(x=>x.categores).Include(x=>x.ProductBrands).Where(x => x.ID == id).ToListAsync();
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
        public async Task<IEnumerable<ProductGallary>> GetByIDTolistImg(int? id)
        {
            return await _context.ProductGallarys.Where(ww => ww.productId == id).ToListAsync();
        }
    }
}

