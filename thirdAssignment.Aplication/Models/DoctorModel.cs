
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Models
{
    public class DoctorModel 
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Cedula { get; set; }
        public string? ImgPath { get; set; }
    //    public Guid ConsultingRoomId { get; set; }
      //  public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
