using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model.Dashbord.Order;
using WebApplication1.Model.Repositery;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord;
using WebApplication1.Model.RepositeryDashboroad;
using WebApplication1.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Model.Order;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OredrProductsController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IRepositerCart cartRepositer;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepositeryProductClotes repo_Product;

        public OredrProductsController(ApplicationContext context,IMapper Mapper, IRepositerCart cartRepositer, UserManager<ApplicationUser> userManager, IRepositeryProductClotes repo_product)
        {
            this.context = context;
            mapper = Mapper;
            this.cartRepositer = cartRepositer;
            this.userManager = userManager;
            repo_Product = repo_product;
        }
        // GET: api/Basket/Detailspro/2
        [HttpGet("Detailsproduct_Order")]
        [Authorize]
        public async Task<ActionResult<Dto.cartShopDto>> Getproduct(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            
            ProductClothe pro = await repo_Product.GetById(id);
            OredrProduct shop = new OredrProduct()
            {
                NameProduct = pro.Name,
                Price=pro.Price,
                descripation = pro.Description,
                IDProduct = pro.ID,
                image_product=pro.PictureUrl,
                emailUser= user.Email
            };

            return Ok(mapper.Map<OredrProduct, cartShopDto>(shop));

        }
        [HttpPost("createOrder")]
        public async Task<ActionResult> createOrder(OrderUser orderuser)
        {
            if (ModelState.IsValid)
            {
                var shopdb = context.OrderUsers.Where(x => x.IdProduct == orderuser.IdProduct && x.email == orderuser.email).FirstOrDefault();
                if (shopdb == null)
                {
                    context.OrderUsers.Add(orderuser);
                }
                else
                {
                    shopdb.count += orderuser.count;
                }
                await context.SaveChangesAsync();
                return Ok();
            }
            return RedirectToAction("getAllOrder");
        }
        [HttpGet("getAllOrder")]
        [Authorize]
        public async Task<ActionResult> getAllOrder(string data)
        {
            var orders = await context.OrderUsers.Where(x => x.email == data).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("getAllOrder_ByConfirm")]
        [Authorize]
        public async Task<ActionResult> getAllOrderConfirm()
        {
            var user = await userManager.FindByEmailWithAddressAsync(HttpContext.User);
            var orders = await context.OrderUsers.Where(x => x.email == user.Email).ToListAsync();
            OrderHeader objList = new OrderHeader();

            objList.OrderDate = DateTime.Now;
            objList.Email = user.Email;
            objList.Address = user.UserName;
            objList.Name = user.FirstName + " " + user.lastName;
            return Ok(objList);
        }
        [HttpPost("getAllOrder_ByConfirmPost")]
        [Authorize]
        public async Task<ActionResult> getAllOrder_ByConfirmPost(OrderHeader[] orderHeader)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in orderHeader)
                {
                  var result= await context.OrderUsers.Where(x => x.IdProduct == item.ServicesOrder).FirstOrDefaultAsync();
                    context.OrderUsers.Remove(result);
                    context.SaveChanges();
                }
            }
            await context.OrderHeaders.AddRangeAsync(orderHeader);
           await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("removeItem")]
        [Authorize]
        public async Task<ActionResult> remove(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var shop = await context.OrderUsers.FindAsync(id);
                context.OrderUsers.Remove(shop);
                await context.SaveChangesAsync();

            }
            catch (System.Exception)
            {

                throw;
            }
            return RedirectToAction("getAllOrder");

        }

        [HttpGet("minusItem")]
        [Authorize]
        public async Task<IActionResult> minus(int id)//id ====> from cartShop.id
        {
            var shop = await context.OrderUsers.FindAsync(id);
            if (shop.count > 1)
            {
                shop.count -= 1;
            }
            await context.SaveChangesAsync();
            // return Ok();
            return RedirectToAction("getAllOrder");
        }
        //function add product 
        [HttpGet("plusItem")]
        [Authorize]
        public async Task<IActionResult> plus(int id)//pro_id ====> from product.id
        {

            var shop = await context.OrderUsers.FindAsync(id);
            shop.count += 1;
            await context.SaveChangesAsync();
            return RedirectToAction("getAllOrder");
        }

    }
}
