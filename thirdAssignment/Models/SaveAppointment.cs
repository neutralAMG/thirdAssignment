using Microsoft.AspNetCore.Mvc.Rendering;

namespace thirdAssignment.Presentation.Models
{
    public class SaveAppointment
    {
        public  Dictionary<int, List<SelectListItem>> AppointmentList { get; set; } 
        public TimeOnly AppointmentTime { get; set; }
    }
}
