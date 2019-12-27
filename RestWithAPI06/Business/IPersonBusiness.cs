using System.Collections.Generic;
using RestWithAPI.Model;
using RestWithAPI04.Data.VO;

namespace RestWithAPI.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long? id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long? id);
        bool Exists(long? id);
    }
}