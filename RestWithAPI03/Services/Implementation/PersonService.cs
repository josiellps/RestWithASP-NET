using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAPI02.Model;
using RestWithAPI03.Model.Context;

namespace RestWithAPI02.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private MySQLContext _context;
        public PersonService(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.persons.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            var result = _context.persons.SingleOrDefault(p => p.Id == id);
            if (result != null)
            { 
                _context.Remove(result);
                _context.SaveChanges();
            }
        }

        public List<Person> FindAll()
        {
            try
            {
                return _context.persons.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person FindById(long id)
        {
            return _context.persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            if (!Exists(person)) return new Person();

            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            _context.Entry(result).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        private bool Exists(Person person)
        {
            return _context.persons.Any(p => p.Id.Equals(person.Id));
        }
    }
}