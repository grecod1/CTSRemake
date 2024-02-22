using System;
using System.Collections.Generic;
using CTS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CTS.Data.Data;

public partial class CTSContext : DbContext
{
    public CTSContext()
    {
    }

    public CTSContext(DbContextOptions<CTSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<CommunicationType> CommunicationTypes { get; set; }

    public virtual DbSet<County> Counties { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<EventLog> EventLogs { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<OfficeLocation> OfficeLocations { get; set; }

    public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

    public virtual DbSet<PhoneType> PhoneTypes { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<RequestType> RequestTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<RoutingCategory> RoutingCategories { get; set; }

    public virtual DbSet<RoutingEmail> RoutingEmails { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TLHSQL17DEV\\DPI;Initial Catalog=HelplineDB; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Addresses");

            entity.HasIndex(e => e.AddressTypeId, "IX_AddressTypeId");

            entity.HasIndex(e => e.CountyId, "IX_CountyId");

            entity.HasIndex(e => e.TicketId, "IX_TicketId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.IsPobox).HasColumnName("IsPOBox");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AddressType).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddressTypeId)
                .HasConstraintName("FK_dbo.Addresses_dbo.AddressTypes_AddressTypeId");

            entity.HasOne(d => d.County).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountyId)
                .HasConstraintName("FK_dbo.Addresses_dbo.Counties_CountyId");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_dbo.Addresses_dbo.Tickets_TicketId");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AddressTypes");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunicationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.CommunicationTypes");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<County>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Counties");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Emails");

            entity.HasIndex(e => e.TicketId, "IX_TicketId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Emails)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_dbo.Emails_dbo.Tickets_TicketId");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ErrorLogs");

            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<EventLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.EventLogs");

            entity.HasIndex(e => e.EventTypeId, "IX_EventTypeId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.EventType).WithMany(p => p.EventLogs)
                .HasForeignKey(d => d.EventTypeId)
                .HasConstraintName("FK_dbo.EventLogs_dbo.EventTypes_EventTypeId");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.EventTypes");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Images");

            entity.HasIndex(e => e.TicketId, "IX_TicketId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Images)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_dbo.Images_dbo.Tickets_TicketId");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Notes");

            entity.HasIndex(e => e.TicketId, "IX_TicketId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Notes)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_dbo.Notes_dbo.Tickets_TicketId");
        });

        modelBuilder.Entity<OfficeLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.OfficeLocations");

            entity.Property(e => e.CloseDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PhoneNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.PhoneNumbers");

            entity.HasIndex(e => e.PhoneTypeId, "IX_PhoneTypeId");

            entity.HasIndex(e => e.TicketId, "IX_TicketId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.PhoneType).WithMany(p => p.PhoneNumbers)
                .HasForeignKey(d => d.PhoneTypeId)
                .HasConstraintName("FK_dbo.PhoneNumbers_dbo.PhoneTypes_PhoneTypeId");

            entity.HasOne(d => d.Ticket).WithMany(p => p.PhoneNumbers)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_dbo.PhoneNumbers_dbo.Tickets_TicketId");
        });

        modelBuilder.Entity<PhoneType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.PhoneTypes");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Programs");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<RequestType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.RequestTypes");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Roles");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Routes");

            entity.HasIndex(e => e.ProgramId, "IX_ProgramId");

            entity.HasIndex(e => e.RoutingCategoryId, "IX_RoutingCategoryId");

            entity.HasIndex(e => e.TicketId, "IX_TicketId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Program).WithMany(p => p.Routes)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK_dbo.Routes_dbo.Programs_ProgramId");

            entity.HasOne(d => d.RoutingCategory).WithMany(p => p.Routes)
                .HasForeignKey(d => d.RoutingCategoryId)
                .HasConstraintName("FK_dbo.Routes_dbo.RoutingCategories_RoutingCategoryId");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Routes)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_dbo.Routes_dbo.Tickets_TicketId");
        });

        modelBuilder.Entity<RoutingCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.RoutingCategories");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<RoutingEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.RoutingEmails");

            entity.HasIndex(e => e.RoutingCategoryId, "IX_RoutingCategoryId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModificationDate).HasColumnType("datetime");

            entity.HasOne(d => d.RoutingCategory).WithMany(p => p.RoutingEmails)
                .HasForeignKey(d => d.RoutingCategoryId)
                .HasConstraintName("FK_dbo.RoutingEmails_dbo.RoutingCategories_RoutingCategoryId");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Status");

            entity.ToTable("Status");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Tickets");

            entity.HasIndex(e => e.CommunicationTypeId, "IX_CommunicationTypeId");

            entity.HasIndex(e => e.RequestTypeId, "IX_RequestTypeId");

            entity.HasIndex(e => e.StatusId, "IX_StatusId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CommunicationType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CommunicationTypeId)
                .HasConstraintName("FK_dbo.Tickets_dbo.CommunicationTypes_CommunicationTypeId");

            entity.HasOne(d => d.RequestType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.RequestTypeId)
                .HasConstraintName("FK_dbo.Tickets_dbo.RequestTypes_RequestTypeId");

            entity.HasOne(d => d.Status).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_dbo.Tickets_dbo.Status_StatusId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Users");

            entity.HasIndex(e => e.OfficeLocationId, "IX_OfficeLocationId");

            entity.HasIndex(e => e.RoleId, "IX_RoleId");

            entity.Property(e => e.CreatedByUserName).HasColumnName("CreatedBy_UserName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedByUserName).HasColumnName("LastModifiedBy_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.OfficeLocation).WithMany(p => p.Users)
                .HasForeignKey(d => d.OfficeLocationId)
                .HasConstraintName("FK_dbo.Users_dbo.OfficeLocations_OfficeLocationId");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_dbo.Users_dbo.Roles_RoleId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
