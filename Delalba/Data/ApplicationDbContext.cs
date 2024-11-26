using Delalba.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Delalba.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //public DelalbaContext(DbContextOptions<DelalbaContext> options) : base(options)
        //{
        //}
        public DbSet<ProductoEntity> Productos { get; set; }
    }
}
