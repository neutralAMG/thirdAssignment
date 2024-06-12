using System.ComponentModel.DataAnnotations;
using thirdAssignment.Aplication.Models.Appointment;
using thirdAssignment.Aplication.Models.Doctor;
using thirdAssignment.Aplication.Models.LabTest;
using thirdAssignment.Aplication.Models.Patient;


namespace thirdAssignment.Aplication.Models.LabTestAppointment
{
    public class LabTestAppointmentModel
    {
        [Required(ErrorMessage = "the name is a requierd field")]
        public string Name { get; set; }

        public Guid Id { get; set; }

        
        public bool IsNotPending { get; set; }

        [Required(ErrorMessage = "the name is a requierd field")]
        public string TestResult { get; set; }

        public AppointmentModel Appointment { get; set; }

        public LabTestModel LabTest { get; set; }
    }
}
