using System;
using System.Collections.Generic;
using Airport_Controll_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Airport_Controll_System.Data;

public partial class AirportMgmtSystemContext : DbContext
{
    public AirportMgmtSystemContext()
    {
    }

    public AirportMgmtSystemContext(DbContextOptions<AirportMgmtSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Routes> Routes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Airport_Mgmt_System;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportCode).HasName("PK__Airports__4B6773525745C3A5");

            entity.Property(e => e.AirportCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AirportName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Routes>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__Routes__80979AAD5758645D");

            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.DestinationAirportCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SourceAirportCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.DestinationAirportCodeNavigation).WithMany(p => p.RouteDestinationAirportCodeNavigations)
                .HasForeignKey(d => d.DestinationAirportCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Routes__Destinat__276EDEB3");

            entity.HasOne(d => d.SourceAirportCodeNavigation).WithMany(p => p.RouteSourceAirportCodeNavigations)
                .HasForeignKey(d => d.SourceAirportCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Routes__SourceAi__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
