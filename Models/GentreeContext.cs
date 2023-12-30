using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gentreeAPI.Models;

public partial class GentreeContext : DbContext
{
    public GentreeContext()
    {
    }

    public GentreeContext(DbContextOptions<GentreeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Engendre> Engendres { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:gentreeAzure");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .HasColumnName("designation");
            entity.Property(e => e.Idperson).HasColumnName("idperson");
            entity.Property(e => e.Valeur).HasColumnName("valeur");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.Idperson)
                .HasConstraintName("FK_Contact_person");
        });

        modelBuilder.Entity<Engendre>(entity =>
        {
            entity.ToTable("engendre");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Avec).HasColumnName("avec");
            entity.Property(e => e.Datenais)
                .HasColumnType("datetime")
                .HasColumnName("datenais");
            entity.Property(e => e.Enfant).HasColumnName("enfant");
            entity.Property(e => e.Parent).HasColumnName("parent");

            entity.HasOne(d => d.AvecNavigation).WithMany(p => p.EngendreAvecNavigations)
                .HasForeignKey(d => d.Avec)
                .HasConstraintName("FK_parent_second");

            entity.HasOne(d => d.EnfantNavigation).WithMany(p => p.EngendreEnfantNavigations)
                .HasForeignKey(d => d.Enfant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_enfant");

            entity.HasOne(d => d.ParentNavigation).WithMany(p => p.EngendreParentNavigations)
                .HasForeignKey(d => d.Parent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_parent_princ");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_pers");

            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datedec)
                .HasColumnType("datetime")
                .HasColumnName("datedec");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Sexe)
                .HasMaxLength(50)
                .HasColumnName("sexe");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
