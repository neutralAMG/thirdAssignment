
using System.ComponentModel.DataAnnotations;


namespace thirdAssignment.Aplication.Models.User
{
    public class UserModel
    {
        [Required(ErrorMessage = "the name is a requierd field")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public Guid Id { get; set; }

        [Required(ErrorMessage = " the last name is a requierd field")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "the email address is a requierd field")]
        [DataType(DataType.Text)]
        public string EMailAddress { get; set; }


        [Required(ErrorMessage = "the username is a requierd field")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "the cunsulting room is a requierd field")]
        [DataType(DataType.Text)]
        public string ConsultingRoomName { get; set; }

        [Required(ErrorMessage = "the password is a requierd field")]
        [DataType(DataType.Text)]
        public string Password { get; set; }


        public UserRolModel UserRol { get; set; }
        public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
