using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Model;
using WebApplication1.Model.Repositery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IrepositeryCat repo;

        public CategoryController(IrepositeryCat repo)
        {
            this.repo = repo;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
          var data=await repo.GetAll();
            List<categore> cat = (List<categore>)data;

            List<Caregory_And_Product> model = new List<Caregory_And_Product>();
            foreach (var item in cat)
            {
                Caregory_And_Product cat1 = new Caregory_And_Product { ID = item.ID, Name = item.Name };
               
                foreach (var itemPro in item.products)
                {
                //Caregory_And_Product caregory_And_Product = new Caregory_And_Product();
                     
                    cat1.product.Add(new Product_Details { ID = itemPro.ID, Name_Product = itemPro.Name });
                }
                model.Add(cat1);
            }
            //return Ok(mapper.Map<IReadOnlyList<categore>, IReadOnlyList<Caregory_And_Product>>(cat));

            return Ok(data);
        }
        // GET api/<CategoryController>/5
        [HttpGet("{id:int}", Name = "getOneRoute")]
        public async Task<ActionResult> Get(int id)
        {
            var data = await repo.GetById(id);
            return Ok(data);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post(categore categore)
        {
            if (ModelState.IsValid)
            {
                
                    await repo.Add(categore);
                    //string url = Url.Link("getOneRoute", new { id = categore.ID });
                    return Ok();
            }
            return RedirectToAction("Get");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, categore categore)
        {
            if (ModelState.IsValid)
            {
                 
                     repo.update(categore);
                //string url = Url.Link("getOneRoute", new { id = categore.ID });
                //return Created(url, categore);
                return Ok();

            }
            return BadRequest(ModelState);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id != null)
            {
                categore data =  await repo.GetById(id);
                repo.Delete(data);
                return RedirectToAction("Get");
            }
            return BadRequest();
        }
    }
}
