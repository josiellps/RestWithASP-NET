using RestWithAPI.Model.Base;

namespace RestWithAPI.Model
{
    public class Person:BaseEntity
    {
        //public int? Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}