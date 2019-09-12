using System.Collections.Generic;
using RestWithAPI03.Model;

namespace RestWithAPI03.Business
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