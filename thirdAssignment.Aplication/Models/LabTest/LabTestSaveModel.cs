

using System.ComponentModel.DataAnnotations;

namespace thirdAssignment.Aplication.Models.LabTest
{
    public class LabTestSaveModel
    {
        [Required(ErrorMessage = "the name is a requierd field")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public Guid Id { get; set; }

        public string? Description { get; set; }

        public Guid ConsultingRoomId { get; set; }
    }
}
