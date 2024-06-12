using thirdAssignment.Aplication.Models.Appointment;

namespace thirdAssignment.Presentation.Models
{
    public class CunsultAppointmentModel
    {
        public List<CheckBoxOption> Checkboxes { get; set; }
        public AppointmentModel AppointmentModel { get; set; }
        public CunsultAppointmentModel()
        {
            Checkboxes = new List<CheckBoxOption>();
            AppointmentModel = new AppointmentModel();
        }
    }
}
