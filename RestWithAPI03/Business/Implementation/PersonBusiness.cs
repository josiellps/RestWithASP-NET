using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAPI03.Model;
using RestWithAPI03.Model.Context;
using RestWithAPI03.Repository;
using RestWithAPI03.Business;

namespace RestWithAPI03.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository _personRepository;
        public PersonBusiness(IPersonRepository personRepository)
        {
             _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            try
            {
                _personRepository.Create(person);
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long? id)
        {
            var result = _personRepository.FindById(id);
            if (result != null)
            {
                _personRepository.Delete(id);
            }
        }

        public List<Person> FindAll()
        {
            try
            {
                return _personRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person FindById(long? id)
        {
            return _personRepository.FindById(id);
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _personRepository.FindById(person.Id);

            _personRepository.Update(person);            
            return person;
        }

        public bool Exists(long? id)
        {
            return (_personRepository.FindById(id)?.Id > 0);
        }
    }
}