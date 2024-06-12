

using System.ComponentModel.DataAnnotations;

namespace thirdAssignment.Aplication.Models.User
{
    public class UserSaveModel
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






        public string? ConsultingRoomName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public Guid ConsultingRoomId { get; set; }
        public int RolId { get; set; }

    }
}
