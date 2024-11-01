using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataModel;

public partial class WorldCitiesContext : DbContext
{
    public WorldCitiesContext()
    {
    }

    public WorldCitiesContext(DbContextOptions<WorldCitiesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnetction"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasOne(d => d.Country).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cities_Countries1");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_country");

            entity.Property(e => e.Iso2).IsFixedLength();
            entity.Property(e => e.Iso3).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
