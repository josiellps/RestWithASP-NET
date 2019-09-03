using System.Collections.Generic;
using RestWithAPI02.Model;

namespace RestWithAPI02.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private List<Person> lista = new List<Person>{
                new Person{
                    Id = 1,
                    FirstName = "Josiel",
                    LastName = "Lopes",
                    Gender = "Masculino",
                    Address = "Rua das Couves"
                },
                new Person{
                    Id = 2,
                    FirstName = "Viviane",
                    LastName = "Peres",
                    Gender = "Feminino",
                    Address = "Rua doze de outubro"
                },
                new Person{
                    Id = 3,
                    FirstName = "Jandira",
                    LastName = "Martins",
                    Gender = "Feminino",
                    Address = "Rua Catanduva"
                }
            };

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            return lista;
        }

        public Person FindById(long id)
        {
            Person person = null;

            foreach (var item in lista)
            {
                if (item.Id == id) return item;
            }
            return person;
        }

        public Person Update(Person person)
        {
            var i = lista.Find(p => p.Id == person.Id);
            if (i != null)
            {
                lista[lista.IndexOf(i)] = person;
                return person;
            }
            return null;
        }
    }
}