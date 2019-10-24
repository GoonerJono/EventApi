using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventWebApi2.Models
{
    public partial class EventManagerContext : DbContext
    {
        public EventManagerContext()
        {
        }

        public EventManagerContext(DbContextOptions<EventManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AppointmentRejection> AppointmentRejection { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<OrganizationSub> OrganizationSub { get; set; }
        public virtual DbSet<OrganizationTimes> OrganizationTimes { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<RegisteredConsultant> RegisteredConsultant { get; set; }
        public virtual DbSet<RegisteredOrganization> RegisteredOrganization { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUser { get; set; }
        public virtual DbSet<TypeOfService> TypeOfService { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=mssqlssd2.zadns.co.za;Initial Catalog=EventManager;Persist Security Info=True;User ID=jabate;Password=Gooner1478@#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "jabate");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment", "dbo");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TicketNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.ConsultantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_RegisteredConsultant");

                entity.HasOne(d => d.TypeOfService)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.TypeOfServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_TypeOfService");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_User");
            });

            modelBuilder.Entity<AppointmentRejection>(entity =>
            {
                entity.ToTable("AppointmentRejection", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentRejection)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppointmentRejection_Appointment");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.ToTable("emailTemplate", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmailTemplate1)
                    .HasColumnName("emailTemplate")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrganizationSub>(entity =>
            {
                entity.ToTable("OrganizationSub", "dbo");

                entity.Property(e => e.IsPaid).HasColumnName("isPaid");

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.OrganizationSub)
                    .HasForeignKey(d => d.OrganisationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationSub_RegisteredOrganization");
            });

            modelBuilder.Entity<OrganizationTimes>(entity =>
            {
                entity.ToTable("OrganizationTimes", "dbo");

                entity.Property(e => e.CloseTime).HasColumnType("time(4)");

                entity.Property(e => e.OpenTime).HasColumnType("time(4)");

                entity.Property(e => e.OrganizationEndDay)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationStartDay)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationTimes)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationTimes_RegisteredOrganization");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province", "dbo");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisteredConsultant>(entity =>
            {
                entity.ToTable("RegisteredConsultant", "dbo");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisteredOrganization>(entity =>
            {
                entity.ToTable("RegisteredOrganization", "dbo");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredDate).HasColumnType("datetime");

                entity.Property(e => e.Suburb)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.RegisteredOrganization)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Province_RegisteredOrganization");

                entity.HasOne(d => d.TypeOfService)
                    .WithMany(p => p.RegisteredOrganization)
                    .HasForeignKey(d => d.TypeOfServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisteredOrganization_TypeOfService");
            });

            modelBuilder.Entity<RegisteredUser>(entity =>
            {
                entity.ToTable("RegisteredUser", "dbo");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CellphoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsVerified).HasColumnName("isVerified");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeOfService>(entity =>
            {
                entity.ToTable("TypeOfService", "dbo");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
