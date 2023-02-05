using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Entities
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<ChooseTreeCat> ChooseTreeCats { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<OrderHaveTree> OrderHaveTrees { get; set; } = null!;
        public virtual DbSet<OrderInCart> OrderInCarts { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Tree> Trees { get; set; } = null!;
        public virtual DbSet<TreeCatHaveType> TreeCatHaveTypes { get; set; } = null!;
        public virtual DbSet<TreeCategory> TreeCategories { get; set; } = null!;
        public virtual DbSet<TreeHaveTreeCat> TreeHaveTreeCats { get; set; } = null!;
        public virtual DbSet<TreeHaveTreeType> TreeHaveTreeTypes { get; set; } = null!;
        public virtual DbSet<TreeOrder> TreeOrders { get; set; } = null!;
        public virtual DbSet<TreeType> TreeTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ReunKraJok_backend")
                .UseCollation("Thai_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Admin_Order");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ChooseTreeCat>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CategoryId });

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ChooseTreeCats)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Choose_TreeCat_TreeCategory");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChooseTreeCats)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Choose_TreeCat_User");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Comment_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<OrderHaveTree>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.TreeId });

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHaveTrees)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_have_Tree_Order");

                entity.HasOne(d => d.Tree)
                    .WithMany(p => p.OrderHaveTrees)
                    .HasForeignKey(d => d.TreeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_have_Tree_Tree1");
            });

            modelBuilder.Entity<OrderInCart>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CartId });

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.OrderInCarts)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_in_Cart_Cart");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderInCarts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_in_Cart_Order");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_User");
            });

            modelBuilder.Entity<Tree>(entity =>
            {
                entity.Property(e => e.TreeId).ValueGeneratedNever();

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Trees)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tree_Admin");
            });

            modelBuilder.Entity<TreeCatHaveType>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.TypeId })
                    .HasName("PK_TreeCat_Have_Type_1");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TreeCatHaveTypes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TreeCat_Have_Type_TreeCategory");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TreeCatHaveTypes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TreeCat_Have_Type_TreeType");
            });

            modelBuilder.Entity<TreeCategory>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TreeHaveTreeCat>(entity =>
            {
                entity.HasKey(e => new { e.TreeId, e.CategoryId });
            });

            modelBuilder.Entity<TreeHaveTreeType>(entity =>
            {
                entity.HasKey(e => new { e.TreeId, e.TypeId })
                    .HasName("PK_Tree_have_TreeType_1");

                entity.HasOne(d => d.Tree)
                    .WithMany(p => p.TreeHaveTreeTypes)
                    .HasForeignKey(d => d.TreeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tree_have_TreeType_Tree");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TreeHaveTreeTypes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tree_have_TreeType_TreeType");
            });

            modelBuilder.Entity<TreeOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TreeType>(entity =>
            {
                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.TypeName).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Email).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Password).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PostalCode).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Province).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Tel)
                    .IsFixedLength()
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.UserImg).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.UserName).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_User_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
