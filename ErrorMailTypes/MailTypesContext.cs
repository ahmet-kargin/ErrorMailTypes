using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TemplateContent;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
