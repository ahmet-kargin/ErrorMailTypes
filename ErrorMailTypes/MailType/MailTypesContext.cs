using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ErrorMailTypes.MailType;

public partial class MailTypesContext : DbContext
{
    public MailTypesContext()
    {
    }

    public MailTypesContext(DbContextOptions<MailTypesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MailType> MailTypes { get; set; }

    public virtual DbSet<MailTypeDto> MailTypeDtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MailTypes;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MailType>(entity =>
        {
            entity.HasKey(e => e.MailTypeId).HasName("PK__MailType__C512A56DF27B51A5");

            entity.ToTable("MailType");

            entity.Property(e => e.MailTypeId).HasColumnName("MailTypeID");
            entity.Property(e => e.MailType1)
                .HasMaxLength(150)
                .HasColumnName("MailType");
        });

        modelBuilder.Entity<MailTypeDto>(entity =>
        {
            entity.HasKey(e => e.MailTypeId);

            entity.Property(e => e.MailTypeId).HasColumnName("MailTypeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
