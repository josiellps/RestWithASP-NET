using System.Collections.Generic;
using RestWithAPI.Model;
using RestWithAPI04.Data.VO;

namespace RestWithAPI.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO person);
        BookVO FindById(long? id);
        List<BookVO> FindAll();
        BookVO Update(BookVO person);
        void Delete(long? id);
        bool Exists(long? id);
    }
}