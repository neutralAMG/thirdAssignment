
using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Dtos
{
    public record BasePatientDto : BaseDto
    {
        public string Address { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasAllergies { get; set; }
        public string PhoneNumber { get; set; }
        public string Cedula { get; set; }
        public string? ImgPath { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }

    }

    public record SavePatientDto : BasePatientDto
    {
        public DateOnly BirthDate { get; set; }  
        public Guid ConsultingRoomId { get; set; }
    }
    public record UpdatePatientDto : BasePatientDto
    {
        public Guid Id { get; set; }
    }
}
