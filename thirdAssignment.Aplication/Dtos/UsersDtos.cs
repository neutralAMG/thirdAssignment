
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Dtos
{
    public record BaseUserDto : BaseDto
    {
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

       

    }
    public record SaveUserDto : BaseUserDto
    {       
        public Guid ConsultingRoomId { get; set; }
        public string ConsultingRoomName { get; set; }
        public Guid RolId { get; set; }
    }
    public record UpdateUserDto : BaseUserDto
    {
        public Guid Id { get; set; }
    }
}
