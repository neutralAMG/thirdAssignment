using Microsoft.AspNetCore.Mvc.Rendering;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Presentation.Models;
using thirdAssignment.Presentation.Utils.Enums;

namespace thirdAssignment.Presentation.Utils
{
    public class GenerateSelectList
    {
        private readonly List<UserRolModel > rols = ValuesHelper.GetRols().Select(r => r.Value).ToList();

        private readonly  List<AppointmentStateModel> appoinments = ValuesHelper.GetAppointmentState().Select(a => a.Value).ToList();
        public List<SelectListItem> GenereteRollsSelectList()
        {
           
            List<SelectListItem>? AllRols = rols.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name.ToString(),
            }).ToList();

            AllRols.Add(new SelectListItem { Value = null, Selected = true, Text = "Select Rol" });



            return AllRols;
        }
        public List<SelectListItem> GenereteAppointmentStateSelectList()
        {
            List<SelectListItem>? AllappoinmentsState = appoinments.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name,
            }).ToList();

            AllappoinmentsState.Add(new SelectListItem { Value = null, Selected = true, Text = "Select AppointmentState" });
            return AllappoinmentsState;
        }

        public List<SelectListItem> GenereteRollsSelectList(UserModel userModel)
        {

            List<SelectListItem>? AllRols = rols.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name.ToString(),
            }).ToList();

            if (AllRols.Any()) AllRols.Find(p => p.Value == userModel.UserRol.Id.ToString()).Selected = true;

            return AllRols;
        }
        public List<SelectListItem> GenereteAppointmentStateSelectList(AppointmentModel appointmentModel)
        {
            List<SelectListItem>? AllappoinmentsState = appoinments.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name,
            }).ToList();
            
            if (AllappoinmentsState.Any()) AllappoinmentsState.Find(p => p.Value == appointmentModel.AppointmentState.Id.ToString()).Selected = true;

            return AllappoinmentsState;
        }

    }
}
