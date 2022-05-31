using Microsoft.EntityFrameworkCore;
using SaleOfDolls.Models;

namespace SaleOfDolls.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Doll> Dolls{ get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Solicitation> Solicitations { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EQA7PL2\\SQLEXPRESS; Initial Catalog=Dolls; Integrated Security=True");
        }
    }
}
