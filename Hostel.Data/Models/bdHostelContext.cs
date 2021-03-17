using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hostel.Data.Models
{
    public partial class bdHostelContext : DbContext
    {
        public bdHostelContext()
        {
        }

        public bdHostelContext(DbContextOptions<bdHostelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Handling> Handling { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=HOME-PC\\SQLEXPRESS;Initial Catalog=bdHostel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DatofBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatofBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdPosition).HasColumnName("id_Position");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__id_Pos__4CA06362");
            });

            modelBuilder.Entity<Handling>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdBooking).HasColumnName("id_Booking");

                entity.Property(e => e.IdClient).HasColumnName("id_Client");

                entity.Property(e => e.IdEmployee).HasColumnName("id_Employee");

                entity.Property(e => e.IdRoom).HasColumnName("id_Room");

                entity.Property(e => e.IdService).HasColumnName("id_Service");

                entity.Property(e => e.IdService2).HasColumnName("id_Service2");

                entity.Property(e => e.IdService3).HasColumnName("id_Service3");

                entity.Property(e => e.InCheck)
                    .HasColumnName("inCheck")
                    .HasColumnType("date");

                entity.Property(e => e.OutCheck)
                    .HasColumnName("outCheck")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdBookingNavigation)
                    .WithMany(p => p.Handling)
                    .HasForeignKey(d => d.IdBooking)
                    .HasConstraintName("FK__Handling__id_Boo__778AC167");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Handling)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Handling__id_Cli__72C60C4A");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Handling)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Handling__id_Emp__71D1E811");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Handling)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Handling__id_Roo__73BA3083");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.HandlingIdServiceNavigation)
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("FK__Handling__id_Ser__74AE54BC");

                entity.HasOne(d => d.IdService2Navigation)
                    .WithMany(p => p.HandlingIdService2Navigation)
                    .HasForeignKey(d => d.IdService2)
                    .HasConstraintName("FK__Handling__id_Ser__75A278F5");

                entity.HasOne(d => d.IdService3Navigation)
                    .WithMany(p => p.HandlingIdService3Navigation)
                    .HasForeignKey(d => d.IdService3)
                    .HasConstraintName("FK__Handling__id_Ser__76969D2E");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NameService)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
