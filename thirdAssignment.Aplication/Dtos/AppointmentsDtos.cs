
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Dtos
{
    public record BaseAppointmentDto : BaseDto
    {
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string AppointmentCause { get; set; }


    }
    public record SaveAppointmentsDto : BaseAppointmentDto
    {
        public int AppointmentStateId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid ConsultingRoomId { get; set; }
    }
    public record UpdateAppointmentsDto : BaseAppointmentDto
    {
        public Guid Id { get; set; }
    }
}
