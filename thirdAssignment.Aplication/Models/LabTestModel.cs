


namespace thirdAssignment.Aplication.Models
{
    public class LabTestModel 
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid ConsultingRoomId { get; set; }
        public ConsultingRoomModel ConsultingRoom { get; set; }
    }
}
