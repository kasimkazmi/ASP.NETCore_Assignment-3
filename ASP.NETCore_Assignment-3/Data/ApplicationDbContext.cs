using ASP.NETCore_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCore_Assignment_3.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Enables the DbContext to retrieve database connection settings from the application's configuration
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Represents the Product entity in the database
        public DbSet<Product> Products { get; set; }

        // Represents the User entity in the database
        public DbSet<User> Users { get; set; }

        // Represents the Address entity in the database
        public DbSet<Address> Addresses { get; set; }

        // Represents the Comment entity in the database
        public DbSet<Comment> Comments { get; set; }

        // Represents the Cart entity in the database
        public DbSet<Cart> Carts { get; set; }

        // Represents the CartItem entity in the database
        public DbSet<CartItem> CartItems { get; set; }

        // Represents the Order entity in the database
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures a one-to-one relationship between the User and ShippingAddress entities
            modelBuilder.Entity<User>()
                .HasOne(u => u.ShippingAddress)
                .WithOne()
                .HasForeignKey<User>(u => u.ShippingAddressId);

            // Configures a one-to-one relationship between the User and BillingAddress entities
            modelBuilder.Entity<User>()
                .HasOne(u => u.BillingAddress)
                .WithOne()
                .HasForeignKey<User>(u => u.BillingAddressId);


            // Configures a many-to-many relationship between the Product and Cart entities,
            // with a join table CartItem
            modelBuilder.Entity<Product>()
                .HasMany(p => p.CartItems)
                .WithMany(c => c.Products)
                .UsingEntity<CartItem>(
                    j => j.HasOne<Product>().WithMany(p => p.CartItems).HasForeignKey(ci => ci.ProductId),
                    j => j.HasOne<Cart>().WithMany(c => c.CartItems).HasForeignKey(ci => ci.CartId));


            // Configures a one-to-many relationship between the Cart and CartItems entities,
            // with cascading deletes
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configures a one-to-many relationship between the Product and CartItems entities,
            // with nullable deletes
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.CartId, ci.ProductId });

            // Configures a one-to-many relationship between the Comment and User entities
            modelBuilder.Entity<Comment>()
                .HasOne<User>(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configures a one-to-many relationship between the Comment and Product entities
            modelBuilder.Entity<Comment>()
                .HasOne<Product>(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}