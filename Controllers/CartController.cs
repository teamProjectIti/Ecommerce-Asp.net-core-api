using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Extensions;
using WebApplication1.Model.Dashbord;
using WebApplication1.Model.Dashbord.Cart;
using WebApplication1.Model.Repositery;
using WebApplication1.Model.RepositeryDashboroad;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositerCart cartRepositer;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepositeryProductClotes repo_Product;

        public CartController(IMapper mapper, IRepositerCart cartRepositer, UserManager<ApplicationUser> userManager,IRepositeryProductClotes repo_product)
        {
            this.mapper = mapper;
            this.cartRepositer = cartRepositer;
            this.userManager = userManager;
            repo_Product = repo_product;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var user = await userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            basket.email = user.Email;
            if (cartRepositer.Check(user.Email, basket.IDProduct))
            {
                await cartRepositer.Add(basket);
                var count = cartRepositer.GetByIDTolistConnt(user.Email);
                return Ok(count);
            }
            else
            {
                return Ok("This Product Already Exist");
            }

        }



        [HttpGet("BasketProduct")]
        [Authorize]
        public async Task<ActionResult> BasketProduct(string email)
        {
            var user = await userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            var countUserbasket = cartRepositer.GetByIDTolistConnt(email);
            if (countUserbasket != 0)
            {
                IEnumerable<CustomerBasket> countUser = await cartRepositer.GetByIDTolist(email);

                List<ProductClothe> listModel = new List<ProductClothe>();
                foreach (var items in countUser)
                {
                    int ID_Pro = items.IDProduct;
                    var pro = await repo_Product.GetById(ID_Pro);

                    listModel.Add(pro);
                }
                return Ok(mapper.Map<IEnumerable<ProductClothe>, IEnumerable<ProductClothes_Return>>(listModel));

                //return Ok(listModel);

            }
            return Ok("Sorry , your basket is empty");
        }


        [HttpGet("getcounter")]
        [Authorize]
        public async Task<ActionResult<CustomerBasket>> getCount()
        {
            var user = await userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

            var count = cartRepositer.GetByIDTolistConnt(user.Email);
            return Ok(count);
        }
        [HttpGet("GetBasketById")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var user = await userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            var basket = await cartRepositer.GetByIDTolist(user.Email);
            return Ok(basket);
        }
        [HttpGet("GetBasketByIdCount")]
        public async Task<ActionResult> GetBasketByIdCount()
        {
            var user = await userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            var basket = cartRepositer.GetByIDTolistConnt(user.Email);
            return Ok(basket);
        }
    }
}
