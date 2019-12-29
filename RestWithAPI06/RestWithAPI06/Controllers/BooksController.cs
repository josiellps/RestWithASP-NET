using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithAPI.Model;
using RestWithAPI.Business;
using RestWithAPI04.Data.Converters;
using RestWithAPI04.Data.VO;

namespace RestWithAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _bookBusiness;
        private BookConverter _converter;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
            _converter = new BookConverter();
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
                return Ok(_converter.Parse(_bookBusiness.FindById(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookVO books)
        {
            return new ObjectResult(_converter.Parse(_bookBusiness.Create(books)));
        }

        [HttpPut]
        public IActionResult Put([FromBody]BookVO books)
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