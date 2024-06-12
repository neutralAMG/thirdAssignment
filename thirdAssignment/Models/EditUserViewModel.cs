using Microsoft.AspNetCore.Mvc.Rendering;
using thirdAssignment.Aplication.Models.User;

namespace thirdAssignment.Presentation.Models
{
    public class EditUserViewModel
    {
        public List<SelectListItem> rolsChoises { get; set; }

        public UserModel userToEdit { get; set; }
    }
}
