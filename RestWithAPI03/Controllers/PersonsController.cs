using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithAPI03.Model;
using RestWithAPI03.Business;

namespace RestWithAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion( "1.0" )]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]" )]
    public class PersonsController : ControllerBase
    {
        IPersonBusiness _personBusiness;
        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet]
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
        public IActionResult Get(int id)
        {
            try
            {
                var person = _personBusiness.FindById(id);
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

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                return new ObjectResult(_personBusiness.Create(person));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Person person)
        {
            var result = _personBusiness.Update(person);            
                return Ok(result);            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
