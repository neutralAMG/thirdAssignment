using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using thirdAssignment.Aplication.Interfaces.Repository;
using thirdAssignment.Infrastructure.Persistence.Repositories;

namespace thirdAssignment.Infrastructure
{
    public static class ServiceRegistration  
    {
       public static void AddInfraestructuraPersistenceLayer(this IServiceCollection services, IConfiguration config)
        {
            string ConectionString = config.GetConnectionString("Default");

            services.AddDbContext<Infrastructure.Persistence.Context.AppContext>(options => 
            options.UseSqlServer(ConectionString));


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<ILabTestRepository, LabTestRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ILabTestAppointmentRepository, LabTestAppointmentRepository>();

        }
    }
}
