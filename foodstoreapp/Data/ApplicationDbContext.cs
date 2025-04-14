using foodstoreapp.Models;
using Microsoft.EntityFrameworkCore;
namespace foodstoreapp.Data
{


    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(
                DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
                    public DbSet<category> category { get; set; }

        }
    
}
