using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAPI.Model;
using RestWithAPI.Model.Context;
using RestWithAPI.Repository;
using RestWithAPI.Business;
using RestWithAPI.Repository.Generic;

namespace RestWithAPI.Business.Implementation
{
    public class BookBusiness : IBookBusiness
    {
        private IRepository<Books> _bookBusiness;
        public BookBusiness(IRepository<Books> bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        public Books Create(Books books)
        {
            try
            {
                _bookBusiness.Create(books);
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

        public List<Books> FindAll()
        {
            try
            {
                return _bookBusiness.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Books FindById(long? id)
        {
            return _bookBusiness.FindById(id);
        }

        public Books Update(Books books)
        {
            if (!Exists(books.Id)) return new Books();

            var result = _bookBusiness.FindById(books.Id);

            _bookBusiness.Update(books);
            return books;
        }

        public bool Exists(long? id)
        {
            return (_bookBusiness.FindById(id)?.Id > 0);
        }
    }
}