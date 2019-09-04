using Microsoft.EntityFrameworkCore;
using RestWithAPI02.Model;

namespace RestWithAPI03.Model.Context
{
    public class MySQLContext:DbContext
    {
        public MySQLContext()
        {
            
        }

        public MySQLContext(DbContextOptions<MySQLContext> options):base(options)
        {
            
        }

        public DbSet<Person> persons;
    }
}