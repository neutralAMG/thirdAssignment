
using thirdAssignment.Aplication.Core;

namespace thirdAssignment.Aplication.Models
{
    public class AppointmentModel 
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string AppointmentCause { get; set; }

        public int AppointmentStateId { get; set; }
      //  public Guid DoctorId { get; set; }
     //   public Guid PatientId { get; set; }
    //    public Guid ConsultingRoomId { get; set; }

        public ConsultingRoomModel ConsultingRoom { get; set; }

        public DoctorModel Doctor { get; set; }
        public PatientModel Patient { get; set; }
        public AppointmentStateModel AppointmentState { get; set; }

        public IList<LabTestAppointmentModel> labTestAppointments { get; set; }
    }
}
