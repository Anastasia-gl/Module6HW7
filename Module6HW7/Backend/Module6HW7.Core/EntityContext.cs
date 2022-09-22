using Microsoft.EntityFrameworkCore;
using Module6HW7.Core.Entity;

namespace Module6HW7.Core
{
    public class EntityContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EP3R97J;Initial Catalog=Module6HW7;Integrated Security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Product Entity

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasKey(k => k.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();

            //User 

            //modelBuilder.Entity<User>()
            //    .ToTable("User")
            //    .HasKey(k => k.Id);

            //modelBuilder.Entity<User>()
            //    .Property(p => p.Login)
            //    .IsRequired()
            //    .HasMaxLength(20);

            //modelBuilder.Entity<User>()
            //    .Property(p => p.Password)
            //    .IsRequired();
        }
    }
}
