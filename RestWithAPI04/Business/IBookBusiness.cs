using System.Collections.Generic;
using RestWithAPI.Model;

namespace RestWithAPI.Business
{
    public interface IBookBusiness
    {
        Books Create(Books person);
        Books FindById(long? id);
        List<Books> FindAll();
        Books Update(Books person);
        void Delete(long? id);
        bool Exists(long? id);
    }
}