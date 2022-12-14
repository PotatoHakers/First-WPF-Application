
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class ApplicationContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MFCNCQ9\\SQLEXPRESS;Database=Car;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=True;Encrypt=False;");
        }

        public DbSet<Car> Car { get; set; }
    }
}
