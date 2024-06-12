

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace thirdAssignment.Aplication.Models.Doctor
{
    public class DoctorSaveModel
    {
        [Required(ErrorMessage = "the name is a requierd field")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        public Guid ConsultingRoomId { get; set; }
        public Guid Id { get; set; }

        [Required(ErrorMessage = "the last name is a requierd field")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "the email address is a requierd field")]
        [DataType(DataType.EmailAddress)]
        public string EMailAddress { get; set; }

        [Required(ErrorMessage = "the phone number is a requierd field")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "the cedula is a requierd field")]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }


        public string? ImgPath { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }

    }
}
