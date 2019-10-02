using System.Collections.Generic;
using RestWithAPI.Model;

namespace RestWithAPI.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long? id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long? id);
        bool Exists(long? id);
    }
}