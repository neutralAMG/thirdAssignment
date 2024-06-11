
using System.ComponentModel.DataAnnotations;
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Models
{
    public class PatientModel 
    {
        [Required(ErrorMessage = "the name is a requierd field")]
        public string Name { get; set; }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "the last name is a requierd field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "the email adress is a requierd field")]
        public string EMailAddress { get; set; }
        [Required(ErrorMessage = "the phone number is a requierd field")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "the cedula is a requierd field")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "the img path is a requierd field")]
        public string? ImgPath { get; set; }
        [Required(ErrorMessage = "the address is a requierd field")]
        public string Address { get; set; }
        [Required(ErrorMessage = "the is a smoker is a requierd field")]
        public bool IsSmoker { get; set; }
        [Required(ErrorMessage = "the has allergies is a requierd field")]
        public bool HasAllergies { get; set; }
        [Required(ErrorMessage = "the birth date is a requierd field")]
        public DateOnly BirthDate { get; set; } 
        
      //  public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
