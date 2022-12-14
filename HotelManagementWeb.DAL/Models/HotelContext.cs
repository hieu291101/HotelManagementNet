using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Guests> Guests { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NEWBIE\\MYSQLS;Initial Catalog=Hotel;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1).HasMaxLength(100);

                entity.Property(e => e.AddressLine2).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(6);
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.BookingPaymentType).HasMaxLength(50);

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DurationStay).HasMaxLength(10);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GuestId).HasColumnName("GuestID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Bookings__Employ__6FE99F9F");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("FK__Bookings__GuestI__6EF57B66");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__Bookings__HotelI__571DF1D5");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Bookings_Rooms");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK_Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentDescription).HasMaxLength(100);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.HasIndex(e => e.AddressId)
                    .HasName("UNQ_Employee_Address")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeAddressId).HasColumnName("EmployeeAddressID");

                entity.Property(e => e.EmployeeContactNumber).HasMaxLength(12);

                entity.Property(e => e.EmployeeDesignation).HasMaxLength(50);

                entity.Property(e => e.EmployeeEmail).HasMaxLength(50);

                entity.Property(e => e.EmployeeFirstName).HasMaxLength(50);

                entity.Property(e => e.EmployeeLastName).HasMaxLength(50);

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.HasOne(d => d.Address)
                    .WithOne(p => p.Employees)
                    .HasForeignKey<Employees>(d => d.AddressId)
                    .HasConstraintName("FK__Employees__Addre__6C190EBB");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employees__Depar__628FA481");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__Employees__Hotel__5812160E");
            });

            modelBuilder.Entity<Guests>(entity =>
            {
                entity.HasKey(e => e.GuestId);

                entity.Property(e => e.GuestId).HasColumnName("GuestID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.GuestContactNumber).HasMaxLength(12);

                entity.Property(e => e.GuestCreditCard).HasMaxLength(50);

                entity.Property(e => e.GuestEmail).HasMaxLength(50);

                entity.Property(e => e.GuestFirstName).HasMaxLength(50);

                entity.Property(e => e.GuestIdproof)
                    .HasColumnName("GuestIDProof")
                    .HasMaxLength(50);

                entity.Property(e => e.GuestLastName).HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Guests__AddressI__1AD3FDA4");
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.HasKey(e => e.HotelId)
                    .HasName("PK_Hotel");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CheckInTime).HasColumnType("datetime");

                entity.Property(e => e.CheckOutTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.HotelChainId).HasColumnName("HotelChainID");

                entity.Property(e => e.HotelContactNumber).HasMaxLength(12);

                entity.Property(e => e.HotelDescription).HasMaxLength(100);

                entity.Property(e => e.HotelEmailAddress).HasMaxLength(50);

                entity.Property(e => e.HotelName).HasMaxLength(50);

                entity.Property(e => e.HotelWebsite).HasMaxLength(50);

                entity.Property(e => e.StarRatingId).HasColumnName("StarRatingID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Hotels__AddressI__02FC7413");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.RoomCost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RoomTypeDescription).HasMaxLength(100);

                entity.Property(e => e.RoomTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rooms__HotelID__267ABA7A");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rooms__RoomTypeI__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
