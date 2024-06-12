using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Aplication.Utils.SessionHandler;

namespace thirdAssignment.Presentation.Utils.UserValidations
{
    public class UserValidations
	{
		private readonly IHttpContextAccessor _httpContext;

		public UserValidations(IHttpContextAccessor httpContext)
        {
			_httpContext = httpContext;
		}

		public bool HasUser()
		{
			bool hasUser = _httpContext.HttpContext.Session.Get<UserModel>("user") != null ? true: false;
		 return hasUser;
		}

        public bool UserIsAdmin()
        {
            bool userAdmin = _httpContext.HttpContext.Session.Get<UserModel>("user") .UserRol.Id == (int)Enums.UserRolsModel.Admin ? true : false;
            return userAdmin;
        }
        public bool UserIsAssistent()
        {
            bool userAdmin = _httpContext.HttpContext.Session.Get<UserModel>("user").UserRol.Id == (int)Enums.UserRolsModel.Assistent ? true : false;
            return userAdmin;
        }
    }
}
