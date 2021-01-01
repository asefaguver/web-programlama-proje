using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreProje.Models
{
    public partial class BlogdbContext : DbContext
    {
        public BlogdbContext()
        {
        }

        public BlogdbContext(DbContextOptions<BlogdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Uye> Uyes { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-9B0C2CB; Database=Blogdb; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId).ValueGeneratedNever();

                entity.Property(e => e.Baslik).HasMaxLength(50);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Blog_Admin");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Blog_Kategori");
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori");

                entity.Property(e => e.KategoriId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Uye>(entity =>
            {
                entity.ToTable("Uye");

                entity.Property(e => e.UyeId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Yorum>(entity =>
            {
                entity.ToTable("Yorum");

                entity.Property(e => e.YorumId).ValueGeneratedNever();

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Yorums)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Yorum_Admin");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Yorums)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_Yorum_Blog");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
