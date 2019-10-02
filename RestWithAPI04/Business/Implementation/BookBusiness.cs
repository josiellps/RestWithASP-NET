using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAPI.Model;
using RestWithAPI.Model.Context;
using RestWithAPI.Repository;
using RestWithAPI.Business;
using RestWithAPI.Repository.Generic;
using RestWithAPI04.Data.VO;
using RestWithAPI04.Data.Converters;

namespace RestWithAPI.Business.Implementation
{
    public class BookBusiness : IBookBusiness
    {
        private IRepository<Books> _bookBusiness;
        private BookConverter _converter;
        public BookBusiness(IRepository<Books> bookBusiness,BookConverter converter)
        {
            _bookBusiness = bookBusiness;
            _converter = converter;
        }

        public BookVO Create(BookVO books)
        {
            try
            {
                _bookBusiness.Create(_converter.Parse(books));
                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long? id)
        {
            var result = _bookBusiness.FindById(id);
            if (result != null)
            {
                _bookBusiness.Delete(id);
            }
        }

        public List<BookVO> FindAll()
        {
            try
            {
                return _converter.ParseList(_bookBusiness.FindAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BookVO FindById(long? id)
        {
            return _converter.Parse(_bookBusiness.FindById(id));
        }

        public BookVO Update(BookVO books)
        {
            if (!Exists(books.Id)) return new BookVO();

            var result = _bookBusiness.FindById(books.Id);

            _bookBusiness.Update(_converter.Parse(books));
            return books;
        }

        public bool Exists(long? id)
        {
            return (_bookBusiness.FindById(id)?.Id > 0);
        }
    }
}