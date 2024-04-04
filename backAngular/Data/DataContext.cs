using backAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace backAngular.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Zapatilla> Zapatillas { get; set; }
    }
}
