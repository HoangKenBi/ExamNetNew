using Microsoft.EntityFrameworkCore;

namespace ExamNet.entities
{
    public class Datacontext:DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
    }
}
