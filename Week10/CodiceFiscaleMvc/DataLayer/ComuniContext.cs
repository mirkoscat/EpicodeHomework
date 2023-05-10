using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public partial class ComuniContext : DbContext
{
    public ComuniContext()
    {
    }

    public ComuniContext(DbContextOptions<ComuniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comuni> Comunis { get; set; }
    public virtual DbSet<PersonaData> Personas { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=ComuniItalianiApp;Integrated Security=True;TrustServerCertificate=true");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=ComuniItaliani;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comuni>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("comuni");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
