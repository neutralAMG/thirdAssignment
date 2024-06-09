using Microsoft.Extensions.DependencyInjection;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Services;
using thirdAssignment.Aplication.Utils.PasswordHasher;


namespace thirdAssignment.Aplication
{
    public static class ServiceRegistration  
    {
       public static void AddAplicationLayer(this IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<ILabTestService, LabTestService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<ILabTestAppointmentService, LabTestAppointmentService>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
