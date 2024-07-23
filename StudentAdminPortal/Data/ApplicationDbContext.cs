using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Models.Entities;

namespace StudentAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes them to the base class
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet representing the Students table in the database
        public DbSet<Student> Students { get; set; }
    }
}
