using System.Collections.Generic;
using RestWithAPI03.Model;

namespace RestWithAPI03.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long? id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long? id);
        bool Exists(long? id);
    }
}