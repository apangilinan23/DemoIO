using Microsoft.EntityFrameworkCore;

namespace DemoIO.Database
{
    public class MockDbContext : DbContext
    {
        public MockDbContext(DbContextOptions<MockDbContext> options) : base(options)
        {
            
        }

        public DbSet<Address> Address { get; set; }

        public DbSet<ClientAddress> ClientAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
            .HasOne(ca => ca.ClientAddress)
            .WithOne(a => a.Address)
            .HasForeignKey<Address>(ca => ca.Id);
        }
    }
}
