using Microsoft.EntityFrameworkCore;

namespace Inspimo_CQRS.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SAADET\\SQLEXPRESS01;initial Catalog=InspimoCQRSDb;integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}
