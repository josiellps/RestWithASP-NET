using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithAPI02.Model;
using RestWithAPI02.Services;

namespace RestWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var person = _personService.FindAll();
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
                var person = _personService.FindById(id);
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
                return new ObjectResult(_personService.Create(person));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Person person)
        {
            if (_personService.Update(person) != null)
                return Ok(person);
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
