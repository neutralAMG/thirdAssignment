
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Dtos
{
    public record BaseLabTestAppointmentDto : BaseDto
    {
        public bool IsNotPending { get; set; }
        public string TestResult { get; set; }

    }

    public record SaveLabTestAppointmentDto : BaseLabTestAppointmentDto
    {
        public Guid LabTestAppointmentId { get; set; }
        public Guid AppointmetId { get; set; }
        public Guid labTesttId { get; set; }
        public Guid ConsultingRoomId { get; set; }
        public Guid DoctorsId { get; set; }
        public Guid PatientId { get; set; }
    }
    public record UpdateLabTestAppointmentDto : BaseLabTestAppointmentDto
    {
        public Guid Id { get; set; }
    }
}
