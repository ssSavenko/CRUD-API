using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Model
{
    public class DBContextData : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DBContextData()
        {

        }

        public DBContextData(DbContextOptions<DBContextData> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
