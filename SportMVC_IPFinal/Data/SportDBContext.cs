using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SportMVC_IPFinal
{
    public partial class SportDBContext : DbContext
    {
       

        public SportDBContext(DbContextOptions<SportDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=vladimirkar0ef0\\sqlexpress;Initial Catalog=SportDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkSportId).HasColumnName("FK_SportId");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkSport)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.FkSportId)
                    .HasConstraintName("FK__Players__FK_Spor__1273C1CD");
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SportName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
