using Microsoft.EntityFrameworkCore;

namespace ExamNet.entities
{
    public class Datacontext:DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
