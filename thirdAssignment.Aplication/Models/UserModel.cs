
using System.ComponentModel.DataAnnotations;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Domain.Entities;

namespace thirdAssignment.Aplication.Models
{
    public class UserModel 
    {
        [Required( ErrorMessage = "the name is a requierd field")]
        public string Name { get; set; }

        public Guid Id { get; set; }

        [Required(ErrorMessage = " the last name is a requierd field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "the email address is a requierd field")]
        public string EMailAddress { get; set; }


        [Required(ErrorMessage = "the username is a requierd field")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "the cunsulting room is a requierd field")]
        public string ConsultingRoomName { get; set; }

        [Required(ErrorMessage = "the password is a requierd field")]
        public string Password { get; set; }


        public UserRolModel UserRol { get; set; }
        public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
