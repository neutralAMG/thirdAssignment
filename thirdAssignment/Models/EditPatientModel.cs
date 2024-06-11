using Microsoft.AspNetCore.Mvc.Rendering;
using thirdAssignment.Aplication.Dtos;
using thirdAssignment.Aplication.Models;

namespace thirdAssignment.Presentation.Models
{
    public class EditPatientModel
    {
        public Dictionary<int, List<SelectListItem>> Checkboxes { get; set; }
        public PatientModel patientModel { get; set; }
    }
}
