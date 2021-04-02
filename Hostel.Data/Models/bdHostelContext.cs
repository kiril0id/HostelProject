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
        public virtual DbSet<ClientWeb> ClientWeb { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Handling> Handling { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomProp> RoomProp { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HOME-PC\\SQLEXPRESS;Initial Catalog=bdHostel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ClientWeb>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__ClientWe__A6A610D4A057DCD9");

                entity.Property(e => e.IdClient)
                    .HasColumnName("idClient")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithOne(p => p.ClientWeb)
                    .HasForeignKey<ClientWeb>(d => d.IdClient)
                    .HasConstraintName("FK__ClientWeb__idCli__3E1D39E1");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.ClientWeb)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__ClientWeb__idRol__3F115E1A");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatofBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdPosition).HasColumnName("id_Position");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdPosition)
                    .HasConstraintName("FK__Employee__id_Pos__0D7A0286");
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
                    .HasConstraintName("FK__Handling__id_Boo__160F4887");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Handling)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__Handling__id_Cli__114A936A");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Handling)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__Handling__id_Emp__10566F31");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Handling)
                    .HasForeignKey(d => d.IdRoom)
                    .HasConstraintName("FK__Handling__id_Roo__123EB7A3");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.HandlingIdServiceNavigation)
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("FK__Handling__id_Ser__1332DBDC");

                entity.HasOne(d => d.IdService2Navigation)
                    .WithMany(p => p.HandlingIdService2Navigation)
                    .HasForeignKey(d => d.IdService2)
                    .HasConstraintName("FK__Handling__id_Ser__14270015");

                entity.HasOne(d => d.IdService3Navigation)
                    .WithMany(p => p.HandlingIdService3Navigation)
                    .HasForeignKey(d => d.IdService3)
                    .HasConstraintName("FK__Handling__id_Ser__151B244E");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RoomProp>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK__RoomProp__E5F8C22624F74139");

                entity.Property(e => e.IdRoom)
                    .HasColumnName("idRoom")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tv).HasColumnName("TV");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithOne(p => p.RoomProp)
                    .HasForeignKey<RoomProp>(d => d.IdRoom)
                    .HasConstraintName("FK__RoomProp__idRoom__282DF8C2");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NameService)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
