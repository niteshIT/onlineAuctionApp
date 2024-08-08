using Microsoft.EntityFrameworkCore;
using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.Data
{
    public class AuctionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bid> Bids { get; set; }

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasIndex(u => u.Email)
           .IsUnique();

            // Product configuration
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany()
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete

            // Bid configuration
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Product)
                .WithMany(p => p.Bids)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Bidder)
                .WithMany()
                .HasForeignKey(b => b.BidderId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete

            modelBuilder.Entity<Product>()
                .Property(p => p.EndTime)
                .HasConversion(
                v => v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Bids)
                .WithOne(b => b.Product)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
