using BulkyProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BulkyProject.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Category { get; set; }
    }
}
