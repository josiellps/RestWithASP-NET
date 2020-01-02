using Microsoft.EntityFrameworkCore;
using RestWithAPI.Model;

namespace RestWithAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Person> persons { get; set; }
        public DbSet<Books> books { get; set; }
    }
}