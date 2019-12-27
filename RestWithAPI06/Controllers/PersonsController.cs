using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithAPI.Model;
using RestWithAPI.Business;
using RestWithAPI.Repository.Generic;
using Tapioca.HATEOAS;
using RestWithAPI04.Data.VO;
using RestWithAPI04.Data.Converters;

namespace RestWithAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : ControllerBase
    {        
        IPersonBusiness _personBusiness;
        PersonConverter _converter;
        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
            _converter = new PersonConverter();
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            try
            {
                var person = _personBusiness.FindAll();
                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(person);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            try
            {
                var person = _personBusiness.FindById(id);
                if (person == null)
                    return NotFound();
                
                return Ok(person);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personBusiness.Create(_converter.Parse(person)));

        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]Person person)
        {
            if(person == null)return BadRequest();

            var result = _personBusiness.Update(_converter.Parse(person));

            if(result == null)return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
