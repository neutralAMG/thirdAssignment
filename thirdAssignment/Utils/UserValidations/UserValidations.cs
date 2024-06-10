using thirdAssignment.Aplication.Models;
using thirdAssignment.Presentation.Utils.SessionHandler;

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

    }
}
