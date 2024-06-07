
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Models
{
    public class PatientModel 
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Cedula { get; set; }
        public string? ImgPath { get; set; }
        public Guid ConsultingRoomId { get; set; }
        public string Address { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasAllergies { get; set; }
        public DateOnly BirthDate { get; set; } 
        
        public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
