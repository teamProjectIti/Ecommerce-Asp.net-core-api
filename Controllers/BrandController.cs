using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord;
using WebApplication1.Model.Repositery;
using WebApplication1.Model.RepositeryDashboroad;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IRepositeryBrand _repo;

        public BrandController(IRepositeryBrand repo)
        {
            this._repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var model =await _repo.GetAll();
            return Ok(model);
        }
        // GET api/<CategoryController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var data = await _repo.GetById(id);
            return Ok(data);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post(ProductBrand ProductBrand)
        {
            if (ModelState.IsValid)
            {

                await _repo.Add(ProductBrand);
                string url = Url.Link("getOneRoute", new { id = ProductBrand.ID });
                return Created(url, ProductBrand);
            }
            return RedirectToAction("Get");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProductBrand ProductBrand)
        {
            if (ModelState.IsValid)
            {

                _repo.update(ProductBrand);
                string url = Url.Link("getOneRoute", new { id = ProductBrand.ID });
                return Created(url, ProductBrand);

            }
            return BadRequest(ModelState);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id != null)
            {
                ProductBrand data = await _repo.GetById(id);
                _repo.Delete(data);
                return Ok();
            }
            return BadRequest();
        }
    }
}
