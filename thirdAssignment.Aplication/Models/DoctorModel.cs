
using System.ComponentModel.DataAnnotations;
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Models
{
    public class DoctorModel 
    {
        [Required(ErrorMessage = "the name is a requierd field")]
        public string Name { get; set; }
        public Guid Id { get; set; }
        [Required(ErrorMessage = "the last name is a requierd field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "the email address is a requierd field")]
        public string EMailAddress { get; set; }
        [Required(ErrorMessage = "the phone number is a requierd field")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "the cedula is a requierd field")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "the image path is a requierd field")]
        public string ImgPath { get; set; }
    //    public Guid ConsultingRoomId { get; set; }
      //  public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
