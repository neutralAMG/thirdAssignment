
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Dtos
{
    public record BaseLabTestDto : BaseDto
    {

        public string? Description { get; set; }
       
    }

    public record SaveLabTestDto : BaseLabTestDto
    {
        public Guid ConsultingRoomId { get; set; }
    }
    public record UpdateLabTestDto : BaseLabTestDto
    {
        public Guid Id { get; set; }
    }
}
