using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Context
{
    public class BookStoreContext : DbContext
    {
        protected BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(d => d.BookId);

                entity.HasOne(d => d.Customer)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });
        }
    }
}