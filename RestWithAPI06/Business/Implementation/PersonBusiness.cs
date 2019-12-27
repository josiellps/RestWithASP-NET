using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAPI.Model;
using RestWithAPI.Model.Context;
using RestWithAPI.Repository;
using RestWithAPI.Business;
using RestWithAPI04.Data.Converters;
using RestWithAPI04.Data.VO;

namespace RestWithAPI.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository _personRepository;
        private readonly PersonConverter _converter;
        public PersonBusiness(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            try
            {
                var _personEntity = _converter.Parse(person);
                return _converter.Parse(_personRepository.Create(_personEntity));
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

        public List<PersonVO> FindAll()
        {
            try
            {
                return _converter.ParseList(_personRepository.FindAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonVO FindById(long? id)
        {
            return _converter.Parse(_personRepository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            if (!Exists(person.Id)) return new PersonVO();

            var result = _personRepository.FindById(person.Id);
            var personEntity = _converter.Parse(person);

            personEntity  =_personRepository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public bool Exists(long? id)
        {
            return (_personRepository.FindById(id)?.Id > 0);
        }
    }
}