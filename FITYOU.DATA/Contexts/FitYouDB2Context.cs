using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FITYOU.DATA.Models;

namespace FITYOU.DATA.Contexts
{
    public partial class FitYouDB2Context : DbContext
    {
        public FitYouDB2Context()
        {
        }

        public FitYouDB2Context(DbContextOptions<FitYouDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; } = null!;
        public virtual DbSet<DetailPlan> DetailPlans { get; set; } = null!;
        public virtual DbSet<Internet> Internets { get; set; } = null!;
        public virtual DbSet<Office> Offices { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Telecable> Telecables { get; set; } = null!;
        public virtual DbSet<TelecablePackage> TelecablePackages { get; set; } = null!;
        public virtual DbSet<Telephone> Telephones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(80);

                entity.Property(e => e.RegisterUser)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeOfUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Normal')");

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CompanyDetail>(entity =>
            {
                entity.HasIndex(e => e.CompanyId, "IX_CompanyId");

                entity.HasIndex(e => e.DetailPlanId, "IX_DetailPlanId");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CompanyDetails_dbo.Companies_CompanyId");

                entity.HasOne(d => d.DetailPlan)
                    .WithMany(p => p.CompanyDetails)
                    .HasForeignKey(d => d.DetailPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CompanyDetails_dbo.DetailPlans_DetailPlanId");
            });

            modelBuilder.Entity<DetailPlan>(entity =>
            {
                entity.HasIndex(e => e.InternetId, "IX_InternetId");

                entity.HasIndex(e => e.TelecableId, "IX_TelecableId");

                entity.HasIndex(e => e.TelephoneId, "IX_TelephoneId");

                entity.HasOne(d => d.Internet)
                    .WithMany(p => p.DetailPlans)
                    .HasForeignKey(d => d.InternetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DetailPlans_dbo.Internets_InternetId");

                entity.HasOne(d => d.Telecable)
                    .WithMany(p => p.DetailPlans)
                    .HasForeignKey(d => d.TelecableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DetailPlans_dbo.Telecables_TelecableId");

                entity.HasOne(d => d.Telephone)
                    .WithMany(p => p.DetailPlans)
                    .HasForeignKey(d => d.TelephoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DetailPlans_dbo.Telephones_TelephoneId");
            });

            modelBuilder.Entity<Internet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.TypeOfNet).HasMaxLength(30);
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasIndex(e => e.CompanyId, "IX_CompanyId");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Offices_dbo.Companies_CompanyId");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Chanels).HasMaxLength(4);

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasIndex(e => e.AdministratorId, "IX_AdministratorId");

                entity.HasIndex(e => e.CompanyId, "IX_CompanyId");

                entity.HasIndex(e => e.InternetId, "IX_InternetId");

                entity.HasIndex(e => e.TelecableId, "IX_TelecableId");

                entity.HasIndex(e => e.TelephoneId, "IX_TelephoneId");

                entity.Property(e => e.ActiveTime).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.TypeOfPlan).HasMaxLength(1);

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.AdministratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Plans_dbo.Administrators_AdministratorId");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Plans_dbo.Companies_CompanyId");

                entity.HasOne(d => d.Internet)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.InternetId)
                    .HasConstraintName("FK_dbo.Plans_dbo.Internets_InternetId");

                entity.HasOne(d => d.Telecable)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.TelecableId)
                    .HasConstraintName("FK_dbo.Plans_dbo.Telecables_TelecableId");

                entity.HasOne(d => d.Telephone)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.TelephoneId)
                    .HasConstraintName("FK_dbo.Plans_dbo.Telephones_TelephoneId");
            });

            modelBuilder.Entity<Telecable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Chanels).HasMaxLength(4);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.TypeOfTelecable).HasMaxLength(30);
            });

            modelBuilder.Entity<TelecablePackage>(entity =>
            {
                entity.HasIndex(e => e.PackageId, "IX_PackageId");

                entity.HasIndex(e => e.TelecableId, "IX_TelecableId");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.TelecablePackages)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TelecablePackages_dbo.Packages_PackageId");

                entity.HasOne(d => d.Telecable)
                    .WithMany(p => p.TelecablePackages)
                    .HasForeignKey(d => d.TelecableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TelecablePackages_dbo.Telecables_TelecableId");
            });

            modelBuilder.Entity<Telephone>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Minutes).HasMaxLength(5);

                entity.Property(e => e.Service).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
