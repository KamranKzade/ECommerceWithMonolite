using ECommorce.WebUI.ExtentionMethod;
using ECommorce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommorce.WebUI.Controllers
{
	public class SessionController : Controller
	{
		private IHttpContextAccessor _httpContextAccessor;

		public SessionController(IHttpContextAccessor contextAccessor)
		{
			_httpContextAccessor = contextAccessor;
		}

		public IActionResult Index()
		{
			//var age = _httpContextAccessor.HttpContext.Session.GetInt32("age");
			//var name = _httpContextAccessor.HttpContext.Session.GetString("name");
			//return OK(age + " " + name);

			var student = _httpContextAccessor.HttpContext.Session.GetObject<StudentTest>("student");
			return Json(student);
		}
		public string Set()
		{
			_httpContextAccessor.HttpContext.Session.SetInt32("age", 24);
			_httpContextAccessor.HttpContext.Session.SetString("name", "Kamran");


			var student = new StudentTest
			{
				Id = 11,
				Name = "Kamran",
				Surname = "Karimzada",
				Age = 24
			};

			_httpContextAccessor.HttpContext.Session.SetObject("student", student);
			return "Data set to session successfully";
		}
	}
}
