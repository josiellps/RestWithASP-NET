using System.Collections.Generic;
using System.Linq;
using RestWithAPI.Model;
using RestWithAPI.Data.Converter;
using RestWithAPI.Data.VO;

namespace RestWithAPI.Data.Converters
{
    public class BookConverter : IParser<BookVO, Books>, IParser<Books, BookVO>
    {
        public BookVO Parse(Books origin)
        {
            if (origin == null) return new BookVO();
            return new BookVO()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public Books Parse(BookVO origin)
        {
            if (origin == null) return new Books();
            return new Books()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<BookVO> ParseList(List<Books> origin)
        {
            if (origin == null) return new List<BookVO>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Books> ParseList(List<BookVO> origin)
        {
            if (origin == null) return new List<Books>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}