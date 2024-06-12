
using System.ComponentModel.DataAnnotations;

namespace thirdAssignment.Aplication.Models.LabTestAppointment
{
    public class LabTestAppointmentSaveModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "the name is a requierd field")]
        public string TestResult { get; set; }


        public Guid AppointmetId { get; set; }

        [Required(ErrorMessage = "the lab test is a requierd field")]
        public Guid labTesttId { get; set; }

        public Guid ConsultingRoomId { get; set; }



        public bool IsNotPending { get; set; }
    }
}
