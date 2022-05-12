using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication1.Cluster;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord;
using WebApplication1.Model.RepositeryDashboroad;
using WebApplication1.Model.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductClothesController : ControllerBase
    {
        private readonly IRepositeryProductClotes _repo;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHost;

        public ProductClothesController(IRepositeryProductClotes repo,IMapper mapper, IWebHostEnvironment webHost)
        {
            this._repo = repo;
            this.mapper = mapper;
            this.webHost = webHost;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var pro = await _repo.GetById(id);
            var productReurn = mapper.Map<ProductClothes_Return>(pro);
            return Ok(productReurn);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult> Postproduct([FromForm] ProductViewModel productModel)
        {
            if (productModel.PictureUrl != null)
            {
                string folder = "ImageProduct/";
                productModel.ConvertPictureUrl = UploadImage(folder, productModel.PictureUrl);
            }
            if (productModel.picturGallaryFils != null)
            {
                string folder = "ImageProduct/gallary/";
                productModel.Gallery = new List<gallaryModel>();
                foreach (var item in productModel.picturGallaryFils)
                {
                    var gallary = new gallaryModel()
                    {
                        Name = item.Name,
                        Url = UploadImage(folder, item)
                    };
                    productModel.Gallery.Add(gallary);

                }
            }
            await _repo.Add_entity(productModel);
            return Ok();

            // return CreatedAtAction("Getproduct", new { id = product.Id }, product);
        }
      
            [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductClothes_Return>>> getAllProduct([FromQuery] QueryParamter queryParamter)
        {
            var products =  await _repo.GetAll();

            if (!string.IsNullOrEmpty(queryParamter.Name))
            {
                products = products.Where(x => x.Name.ToLower().Contains(queryParamter.Name.ToLower()) |
                  x.Description.ToLower().Contains(queryParamter.Name.ToLower()));
            }
        if (!string.IsNullOrEmpty(queryParamter.SortBy))
            {
                if (typeof(ProductClothe).GetProperty(queryParamter.SortBy) != null)
                {
                    switch (queryParamter.SortBy)
                    {
                        case "asc":
                            products= products.OrderBy(p => p.Price).ThenBy(x=>x.Name);
                            break;
                        case "priceDesc":
                            products = products.OrderByDescending(p => p.Price).ThenBy(x => x.Name);
                            break;
                        default:
                            products = products.OrderBy(p => p.Name);
                            break;
                    }
                }
            }
            products = products
                .Skip(queryParamter.Size * (queryParamter.page - 1))
                .Take(queryParamter.Size).ToList();

            return Ok(mapper.Map<IEnumerable<ProductClothe>, IEnumerable<ProductClothes_Return>>(products));
        }
        private string UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(webHost.WebRootPath, folderPath);
            file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
        [HttpGet("GetProductGallary/{id}")]
        public async Task<ActionResult<IEnumerable<productGallaryReturnDtos>>> GetProductGallary(int id)
        {
            IEnumerable<ProductGallary> productGallarys = await _repo.GetByIDTolistImg(id);
            if (productGallarys == null)
            {
                return NotFound();
            }
           return Ok(mapper.Map<IEnumerable<ProductGallary>, IEnumerable<productGallaryReturnDtos>>(productGallarys));
        }
    }
}
