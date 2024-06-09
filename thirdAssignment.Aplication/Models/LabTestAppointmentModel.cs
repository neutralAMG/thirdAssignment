
using thirdAssignment.Aplication.Core;


namespace thirdAssignment.Aplication.Models
{
    public class LabTestAppointmentModel 
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
   //     public Guid LabTestAppointmentId { get; set; }
   //     public Guid AppointmetId { get; set; }
   //     public Guid TestId { get; set; }
        public bool IsNotPending { get; set; }
        public string TestResult { get; set; }
      //  public Guid ConsultingRoomId { get; set; }
        public AppointmentModel Appointment { get; set; }
        public DoctorModel Doctor { get; set; }
        public PatientModel Patient { get; set; }
        public LabTestModel LabTest { get; set; }
    }
}
