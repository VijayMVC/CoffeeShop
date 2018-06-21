using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoffeeShop.Models
{
    public partial class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {
        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionItem> TransactionItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LP-9C7BSN2\\MSSQLSERVER01;Initial Catalog=CoffeeShop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductType);
                    //.HasMaxLength(50)
                    //.IsUnicode(false);

                entity.HasOne(d => d.ProductTypeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductType)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ProductType1);

                entity.Property(e => e.ProductType1)
                    .HasColumnName("ProductType");
                    //.HasMaxLength(50)
                    //.IsUnicode(false)
                    //.ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<TransactionItem>(entity =>
            {
                entity.Property(e => e.TransactionItemId).HasColumnName("TransactionItemID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TransactionItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_TransactionItem_Product");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionItem)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_TransactionItem_Transaction");
            });
        }
    }
}
