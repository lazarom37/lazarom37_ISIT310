using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPAPI_mongo.Models;

public partial class BacklogDbContext : DbContext
{
    public BacklogDbContext()
    {
    }

    public BacklogDbContext(DbContextOptions<BacklogDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Backlog> Backlogs { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer("Server=tcp:pinkmachinesql.database.windows.net,1433; Database=isit310db; User ID=azureuser;Password=nintendo3DS;TrustServerCertificate=False; ");
    //=> optionsBuilder.UseSqlServer("Server=A254-T011718M;Database=BacklogDB;Trusted_Connection=True; TrustServerCertificate=True");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.Property(e => e.publisherID).HasColumnName("PublisherID");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.NamePub)
                .HasMaxLength(50)
                .HasColumnName("namePub");
        });

        modelBuilder.Entity<Backlog>(entity =>
        {
            entity.Property(e => e.backlogID).HasColumnName("BacklogID");
            entity.Property(e => e.publisherID).HasColumnName("PublisherID");
            entity.Property(e => e.genreID).HasColumnName("genreID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Platform)
                .HasMaxLength(50)
                .HasColumnName("platform");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Backlogs)
                .HasForeignKey(d => d.publisherID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Backlogs_Publishers");

            entity.HasOne(d => d.Genre).WithMany(p => p.Backlogs)
                .HasForeignKey(d => d.genreID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Backlogs_Genres");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.genreID).HasColumnName("genreID");
            entity.Property(e => e.genreDesc)
                .HasMaxLength(50)
                .HasColumnName("genreDesc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
