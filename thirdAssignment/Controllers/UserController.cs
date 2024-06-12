using Microsoft.AspNetCore.Mvc;
using thirdAssignment.Aplication.Core;
using thirdAssignment.Aplication.Interfaces.Contracts;
using thirdAssignment.Aplication.Models.User;
using thirdAssignment.Presentation.Models;
using thirdAssignment.Presentation.Utils;
using thirdAssignment.Presentation.Utils.Enums;
using thirdAssignment.Presentation.Utils.UserValidations;

namespace thirdAssignment.Presentation.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly UserValidations _userValidations;
		private readonly GenerateSelectList _generateSelectList;

		public UserController(IUserService userService, UserValidations userValidations, GenerateSelectList generateSelectList)
		{
			_userService = userService;
			_userValidations = userValidations;
			_generateSelectList = generateSelectList;
		}

		// GET: UserController
		public async Task<IActionResult> Index(Guid id)
		{
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

			Result<List<UserModel>> result = new();
			try
			{

				result = await _userService.GetAll();

				if (!result.IsSuccess)
				{

				}

				return View(result.Data);

			}
			catch
			{

				throw;
			}

		}

		public async Task<IActionResult> Login()
		{
			if (_userValidations.HasUser()) return RedirectToAction("index", "Home");

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(string username, string password)
		{
			if (_userValidations.HasUser()) return RedirectToAction("index", "Home");

			Result<UserModel> result = new();
			try
			{
				result = await _userService.Login(username, password);

				if (!result.IsSuccess)
				{
					ViewBag.Message = "User not found check the username and password digited";
					return View();
				}

				return RedirectToAction("index", "Home");
			}
			catch
			{
				return View();
			}
		}
		public async Task<IActionResult> LogOut()
		{
			HttpContext.Session.Clear();

			return View("Login");
		}

		public async Task<IActionResult> Register()
		{
			if (_userValidations.HasUser()) return RedirectToAction("Index", "Home");
			return View(new UserModel());
		}

		// POST: UserController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(UserSaveModel saveUserDto)
		{

			Result<UserModel> result = new();
			try
			{

				if (!ModelState.IsValid)
				{

					ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
					return View(new UserModel());
				}


				if (saveUserDto.Password != saveUserDto.ConfirmPassword)
				{
					ViewBag.Message = "the password's need to macth";
					return View(new UserModel());

				}

				saveUserDto.RolId = ValuesHelper.GetRols()[UserRolsModel.Admin].Id;

				result = await _userService.Register(saveUserDto);

				if (!result.IsSuccess)
				{
					ViewBag.Message = result.Message;
					return View();
				}

				ViewBag.UserCreated = "User was create now loging!!!!";
				return View("Login");
			}
			catch
			{
				return View();
			}
		}



		// GET: UserController/Create
		public async Task<IActionResult> SaveUser()
		{
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

			return View(_generateSelectList.GenereteRollsSelectList());
		}

		// POST: UserController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SaveUser(UserSaveModel userDto)
		{
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

			Result<UserSaveModel> result = new();
			try
			{

				if (!ModelState.IsValid)
				{

					ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
					return View(_generateSelectList.GenereteRollsSelectList());
				}

				if (userDto.Password != userDto.ConfirmPassword)
				{
					ViewBag.Message = "the password's need to macth";
					return View(_generateSelectList.GenereteRollsSelectList());

				}

				result = await _userService.Save(userDto);

				if (!result.IsSuccess)
				{
					ViewBag.Message = result.Message;
					return View(_generateSelectList.GenereteRollsSelectList());
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserController/Edit/5
		public async Task<IActionResult> EditUser(Guid id)
		{
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

			Result<UserModel> result = new();
			try
			{
				result = await _userService.GetById(id);

				if (!result.IsSuccess)
				{
					ViewBag.Message = result.Message;
					return RedirectToAction(nameof(Index));
				}

				return View(new EditUserViewModel { rolsChoises = _generateSelectList.GenereteRollsSelectList(result.Data), userToEdit = result.Data });

			}
			catch
			{

				throw;
			}

		}

		// POST: UserController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditUser(Guid id, UserSaveModel updateUserDto)
		{
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

			Result<UserSaveModel> result = new();
			try
			{

				Result<UserModel> resultIner = new();
				resultIner = await _userService.GetById(id);

				if (!ModelState.IsValid)
				{
					ViewBag.message = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
				
					return View(new EditUserViewModel { rolsChoises = _generateSelectList.GenereteRollsSelectList(resultIner.Data), userToEdit = resultIner.Data });
				}

				if (updateUserDto.Password != updateUserDto.ConfirmPassword)
				{

					resultIner = await _userService.GetById(id);
					ViewBag.Message = "the password's need to macth";
					return View(new EditUserViewModel { rolsChoises = _generateSelectList.GenereteRollsSelectList(resultIner.Data), userToEdit = resultIner.Data });
				}


				result = await _userService.Update(updateUserDto);

				if (!result.IsSuccess)
				{

					resultIner = await _userService.GetById(id);
					ViewBag.Message = result.Message;
					return View(new EditUserViewModel { rolsChoises = _generateSelectList.GenereteRollsSelectList(resultIner.Data), userToEdit = resultIner.Data });
				}
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserController/Delete/5
		public async Task<IActionResult> DeleteUser(Guid id)
		{
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

			Result<UserModel> result = new();
			try
			{
				result = await _userService.GetById(id);

				if (!result.IsSuccess)
				{
					ViewBag.Message = result.Message;
					return RedirectToAction(nameof(Index));
				}

				return View(result.Data);

			}
			catch
			{

				throw;
			}

		}

		// POST: UserController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteUser(Guid id, IFormCollection collection)
		{
			if (!_userValidations.HasUser()) return RedirectToAction("Login", "User");
			if (!_userValidations.UserIsAdmin()) return RedirectToAction("index", "Home");

			Result<UserModel> result = new();
			try
			{
				result = await _userService.Delete(id);

				if (!result.IsSuccess)
				{
					Result<UserModel> resultIner = new();

					resultIner = await _userService.GetById(id);
					ViewBag.Message = result.Message;
					return RedirectToAction(nameof(Index));
				}
				return RedirectToAction(nameof(Index));

			}
			catch
			{
				return View();
			}
		}

	}
}
