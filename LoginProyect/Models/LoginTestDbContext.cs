using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginProyect.Models;

public partial class LoginTestDbContext : DbContext
{
    public LoginTestDbContext()
    {
    }

    public LoginTestDbContext(DbContextOptions<LoginTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C982B801C8DA");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
