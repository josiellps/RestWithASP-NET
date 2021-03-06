﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithAPI.Model;
using RestWithAPI.Business;
using RestWithAPI.Repository.Generic;

namespace RestWithAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : ControllerBase
    {
        IRepository<Person> _personBusiness;
        public PersonsController(IRepository<Person> personBusiness)
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
                    return NotFound();
                
                return Ok(person);                
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
                return BadRequest();

            return new ObjectResult(_personBusiness.Create(person));

        }

        [HttpPut]
        public IActionResult Put([FromBody]Person person)
        {
            if(person == null)return BadRequest();

            var result = _personBusiness.Update(person);

            if(result == null)return BadRequest();

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
