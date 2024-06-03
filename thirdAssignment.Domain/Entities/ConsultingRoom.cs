

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class ConsultingRoom : BaseEntity
    {
        public Guid ConsultingRoomId { get; set; }
        public IList<User>? users {  get; set; }
        public IList<Appointment> appointments {  get; set; }
        public IList<Patient> patients {  get; set; }
        public IList<Doctor> doctors {  get; set; }
        public IList<LabTestAppointment> labTestAppointments {  get; set; }
        public IList<LabTest> labTests {  get; set; }

    }
}
