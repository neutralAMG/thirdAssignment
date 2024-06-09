
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Dtos
{
    public record BaseDoctorDto : BaseDto
    {
        public string PhoneNumber { get; set; }
        public string Cedula { get; set; }
        public string? ImgPath { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
    }

    public record SaveDoctorDto : BaseDoctorDto
    {

        public Guid ConsultingRoomId { get; set; }
    }
    public record UpdateDoctorDto : BaseDoctorDto
    {
        public Guid Id { get; set; }
    }
}
