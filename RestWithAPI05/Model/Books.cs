using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithAPI.Model.Base;

namespace RestWithAPI.Model
{
    public class Books : BaseEntity
    {
        //[key]
        //[Column("id")]
        //public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}