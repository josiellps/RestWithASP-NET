using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithAPI.Model;
using RestWithAPI.Business;

namespace RestWithAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _bookBusiness;
        
        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = _bookBusiness.FindAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_bookBusiness.FindById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Books books)
        {                      
            return new ObjectResult(_bookBusiness.Create(books));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Books books)
        {
             if (books == null) return BadRequest();

             var result = _bookBusiness.Update(books);

             if (result == null) return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}