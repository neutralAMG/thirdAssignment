using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Infrastructure.Persistence.Context
{
    public class thirdAssignmentAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<LabTestAppointment> LabtestAppointments { get; set; }
        public DbSet<ConsultingRoom> ConsultingRooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentState> AppointmentStates { get; set; }

        public thirdAssignmentAppContext(DbContextOptions<thirdAssignmentAppContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=thirdAssignment; Integrated Security=true; TrustServerCertificate=true;", b => b.MigrationsAssembly("thirdAssignment.Infrastructure.Persistence"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region user configuration
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);
                u.HasOne(u => u.ConsultingRoom);
                u.HasOne(U => U.UserRol);
                u.Property(u => u.Name).IsRequired();
                u.Property(u => u.Id).IsRequired();
                u.Property(u => u.ConsultingRoomId).IsRequired();
                u.Property(u => u.RolId).IsRequired();
                u.Property(u => u.LastName).IsRequired();
                u.Property(u => u.EMailAddress).IsRequired();
                u.Property(u => u.Password).IsRequired();
                u.Property(u => u.UserName).IsRequired();
            });
            #endregion

            #region ConsultingRoom configuration
            modelBuilder.Entity<ConsultingRoom>(c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).IsRequired();

            });
            #endregion

            #region Patient configuration
            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(p => p.Id);
                p.HasOne(p => p.ConsultingRoom);
                p.HasMany(p => p.appointments);
                p.Property(p => p.Name).IsRequired();
                p.Property(p => p.Id).IsRequired();
                p.Property(p => p.ConsultingRoomId).IsRequired();
                p.Property(p => p.PhoneNumber).IsRequired();
                p.Property(p => p.LastName).IsRequired();
                p.Property(p => p.EMailAddress).IsRequired();
                p.Property(p => p.Cedula).IsRequired();
                p.Property(p => p.BirthDate).IsRequired().HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v));
                p.Property(p => p.IsSmoker).IsRequired();
                p.Property(p => p.HasAllergies).IsRequired();
                p.Property(p => p.Address).IsRequired();
                p.Property(p => p.ImgPath);



            });
            #endregion

            #region Doctor configuration
            modelBuilder.Entity<Doctor>(d =>
            {

                d.HasKey(d => d.Id);
                d.HasOne(d => d.ConsultingRoom).WithMany(cr => cr.doctors)
                .HasForeignKey(a => a.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
                d.HasMany(d => d.appointments).WithOne(cr => cr.Doctor)
                .HasForeignKey(a => a.DoctorId).OnDelete(DeleteBehavior.NoAction); 
                d.Property(d => d.Name).IsRequired();
                d.Property(d => d.Id).IsRequired();
                d.Property(d => d.ConsultingRoomId).IsRequired();
                d.Property(d => d.PhoneNumber).IsRequired();
                d.Property(d => d.LastName).IsRequired();
                d.Property(d => d.EMailAddress).IsRequired();
                d.Property(d => d.Cedula).IsRequired();
                d.Property(d => d.ImgPath);
            });
            #endregion

            #region Lab test configuration
            modelBuilder.Entity<LabTest>(l =>
            {

                l.HasKey(l => l.Id);
                l.HasOne(l => l.ConsultingRoom);
                l.HasMany(l => l.labTestAppointments).WithOne(l => l.LabTest)
                .HasForeignKey(l => l.LabTesttId)
                .OnDelete(DeleteBehavior.NoAction);
                l.Property(l => l.Name).IsRequired();
                l.Property(l => l.Id).IsRequired();
                l.Property(l => l.Description);
                l.Property(l => l.ConsultingRoomId).IsRequired();

            });
            #endregion

            #region Lab test appointment configuration
            modelBuilder.Entity<LabTestAppointment>(l =>
            {

                l.HasKey(l => l.Id);
                l.HasOne(l => l.ConsultingRoom).WithMany()
                .HasForeignKey(l => l.ConsultingRoomId)
                .OnDelete(DeleteBehavior.NoAction);

                l.HasOne(l => l.Appointment).WithMany(a => a.labTestAppointments)
                .HasForeignKey(l => l.AppointmetId)
                .OnDelete(DeleteBehavior.NoAction); 

                l.HasOne(l => l.Patient).WithMany()
                .HasForeignKey(l => l.PatientId)
                .OnDelete(DeleteBehavior.NoAction); 

                l.HasOne(l => l.Doctor).WithMany()
                .HasForeignKey(l => l.DoctorsId)
                .OnDelete(DeleteBehavior.NoAction);

                l.HasOne(l => l.LabTest)
                .WithMany( l => l.labTestAppointments )
                .HasForeignKey(l => l.LabTesttId)
                .OnDelete(DeleteBehavior.NoAction); 

                l.Property(l => l.AppointmetId).IsRequired();
                l.Property(l => l.LabTesttId).IsRequired();
                l.Property(l => l.DoctorsId).IsRequired();
                l.Property(l => l.Id).IsRequired();
                l.Property(l => l.ConsultingRoomId).IsRequired();
                l.Property(l => l.IsNotPending).IsRequired();
                l.Property(l => l.TestResult).HasMaxLength(150);

            });
            #endregion

            #region Appointment configuration
            modelBuilder.Entity<Appointment>(a =>
            {
                a.HasKey(l => l.Id);
                a.HasOne(l => l.ConsultingRoom);
                a.HasOne(l => l.Doctor);
                a.HasOne(l => l.Patient).WithMany(p => p.appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
                a.HasMany(l => l.labTestAppointments);
                a.HasOne(l => l.AppointmentState);
                a.Property(l => l.AppointmentDate).IsRequired().HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v));
                a.Property(l => l.AppointmentCause).IsRequired();
                a.Property(l => l.AppointmentTime).IsRequired().HasConversion(v => v.ToTimeSpan(), v => new TimeOnly(v.Ticks));
                a.Property(l => l.Id).IsRequired();
                a.Property(l => l.ConsultingRoomId).IsRequired();
                a.Property(l => l.DoctorId).IsRequired();
                a.Property(l => l.AppointmentStateId).IsRequired();
                a.Property(l => l.PatientId).IsRequired();
            });
            #endregion

            #region User rol configuration
            modelBuilder.Entity<UserRol>(ur =>
            {
                ur.HasKey(ur => ur.Id);
                ur.Property(ur => ur.Name).IsRequired();
                ur.HasData(

                new UserRol { Id = 1, Name = "Admin" },
                new UserRol { Id = 2, Name = "Assistent" }
            );
            });
            #endregion

            #region Appointment state configuration
            modelBuilder.Entity<AppointmentState>(ps =>
            {
                ps.HasKey(ps => ps.Id);
                ps.Property(ps => ps.Name).IsRequired();
                ps.HasData(

                   new AppointmentState { Id = 1, Name = "Pending consultation" },
                   new AppointmentState { Id = 2, Name = "Pending results" },
                   new AppointmentState { Id = 3, Name = "Completed" }
                  );
            });
            #endregion
        }


    }
}
