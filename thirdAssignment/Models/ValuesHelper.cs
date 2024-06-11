using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;
using thirdAssignment.Presentation.Utils.Enums;

namespace thirdAssignment.Presentation.Models
{
    public static class ValuesHelper
    {
        public static Dictionary<Enum, UserRolModel> GetRols()
        {
            Dictionary<Enum, UserRolModel> UserRols = new()
            {
                { UserRolsModel.Admin, new UserRolModel { Id = 1, Name = "Admin" } },
                { UserRolsModel.Assistent, new UserRolModel { Id = 2, Name = "Assistent" } }
            };
            return UserRols;
        }


        public static Dictionary<int, AppointmentStateModel> GetAppointmentState()
        {
            Dictionary<int, AppointmentStateModel> AppointmentState = new()
            {

                {(int)AppointmentStates.PendingCunsult, new AppointmentStateModel { Id = 1, Name = "Pending consultation" } },
                {(int)AppointmentStates.PendingResult, new AppointmentStateModel { Id = 2, Name = "Pending results" } },
                {(int)AppointmentStates.Compleate, new AppointmentStateModel { Id = 3, Name = "Completed" } }
            };
            return AppointmentState;
        }


    }
}
