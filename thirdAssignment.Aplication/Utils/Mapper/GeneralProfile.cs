using AutoMapper;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Aplication.Models.Appointment;
using thirdAssignment.Aplication.Models.Doctor;
using thirdAssignment.Aplication.Models.LabTest;
using thirdAssignment.Aplication.Models.LabTestAppointment;
using thirdAssignment.Aplication.Models.Patient;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Domain.Entities;


namespace thirdAssignment.Aplication.Utils.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
           #region User rol mappings

            CreateMap<UserRol, UserRolModel>()
                 .ReverseMap()
                .ForMember(dest => dest.users, opt => opt.Ignore());

            #endregion

            #region consultingRoom mappings

            CreateMap<ConsultingRoom, ConsultingRoomModel>()
                 .ReverseMap()
                .ForMember(dest => dest.users, opt => opt.Ignore())
                .ForMember(dest => dest.patients, opt => opt.Ignore())
                .ForMember(dest => dest.labTests, opt => opt.Ignore())
                .ForMember(dest => dest.appointments, opt => opt.Ignore())
                .ForMember(dest => dest.doctors, opt => opt.Ignore());

            #endregion

            #region User Mappings

            CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserRol, opt => opt.MapFrom(src => src.UserRol))
                .ForMember(dest => dest.ConsultingRoom, opt => opt.MapFrom(src => src.ConsultingRoom))
                .ReverseMap()
                .ForMember(dest => dest.RolId, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoomId, opt => opt.Ignore());

            CreateMap<User, UserSaveModel>()
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore())
                .ForMember(dest => dest.UserRol, opt => opt.Ignore());


            CreateMap<User, UpdateUserDto>()
                 .ReverseMap()
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore())
                .ForMember(dest => dest.UserRol, opt => opt.Ignore());

            #endregion

             #region Appointment state mappings

            CreateMap<AppointmentState, AppointmentStateModel>()
               .ReverseMap()
               .ForMember(dest => dest.appointments, opt => opt.Ignore());

            #endregion

            #region Doctor mappings

            CreateMap<Doctor, DoctorModel>()
                .ReverseMap()
                .ForMember(dest => dest.appointments, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoomId, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());


            CreateMap<Doctor, DoctorSaveModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore() )
                .ReverseMap()
                .ForMember(dest => dest.appointments, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            CreateMap<Doctor, UpdateDoctorDto>()
                 .ReverseMap()
                .ForMember(dest => dest.appointments, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            #endregion

            #region Patient mappings

            CreateMap<Patient, Models.Patient.PatientModel>()
                .ReverseMap()
                .ForMember(dest => dest.appointments, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoomId, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());


            CreateMap<Patient, PatienSaveModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.appointments, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            CreateMap<Patient, UpdatePatientDto>()
                .ReverseMap()
                .ForMember(dest => dest.appointments, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            #endregion

            #region Appointment mappings

            CreateMap<Appointment, AppointmentModel>()
                .ForMember(dest => dest.AppointmentState, opt => opt.MapFrom(src => src.AppointmentState))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient))
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.labTestAppointments, opt => opt.MapFrom(src => src.labTestAppointments))
                .ReverseMap()
                .ForMember(dest => dest.PatientId, opt => opt.Ignore())
                .ForMember(dest => dest.DoctorId, opt => opt.Ignore())
                .ForMember(dest => dest.AppointmentStateId, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoomId, opt => opt.Ignore());

            CreateMap<Appointment, AppointmentSaveModel>()
                .ReverseMap()
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.AppointmentState, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            CreateMap<Appointment, UpdateAppointmentsDto>()
                .ReverseMap()
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.AppointmentState, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());


            #endregion

            #region Lab test mappings
            CreateMap<LabTest, LabTestModel>()
                .ReverseMap()
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoomId, opt => opt.Ignore());

            CreateMap<LabTest, LabTestSaveModel>()
                 .ReverseMap()
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            CreateMap<LabTest, UpdateLabTestDto>()
                .ReverseMap()
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            #endregion

            #region Lab test appointments mappings
            CreateMap<LabTestAppointment, LabTestAppointmentModel>()

                .ForMember(dest => dest.Appointment, opt => opt.MapFrom(src => src.Appointment))
                .ForMember(dest => dest.LabTest, opt => opt.MapFrom(src => src.LabTest))
                .ReverseMap()
                .ForMember(dest => dest.AppointmetId, opt => opt.Ignore())
                .ForMember(dest => dest.LabTesttId, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoomId, opt => opt.Ignore());

            CreateMap<LabTestAppointment, LabTestAppointmentSaveModel>()
                .ReverseMap()
                .ForMember(dest => dest.Appointment, opt => opt.Ignore())
                .ForMember(dest => dest.LabTest, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());

            CreateMap<LabTestAppointment, UpdateLabTestAppointmentDto>()
                .ReverseMap()
                .ForMember(dest => dest.Appointment, opt => opt.Ignore())
                .ForMember(dest => dest.LabTest, opt => opt.Ignore())
                .ForMember(dest => dest.ConsultingRoom, opt => opt.Ignore());
            #endregion


        }
    }
}
