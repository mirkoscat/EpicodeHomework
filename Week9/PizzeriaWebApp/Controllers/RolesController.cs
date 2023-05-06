using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzeriaWebApp.DataLayer;
using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Controllers
{//devo poter associare un utente a un ruolo ben preciso

	[Authorize(Roles = "admin")]
	public class RolesController : Controller
	{
		private readonly ApplicationDbContext _context = new ApplicationDbContext();
		// GET: Role
		public ActionResult Index()
		{
			var users = _context.Users.Select(x => new UserViewModel
			{
				Id = x.Id,
				Name = x.UserName
			});

			var model = new RolesIndexviewModel
			{

				Users =users
			};
			return View(model);
		}
		public ActionResult Edit(string id)
		{
			var user = _context.Users.Single(u => u.Id == id);
			var roles = _context.Roles.OrderBy(x => x.Name).ToList();
			//dato id ruolo,recupero il nome

			var userRoles = user.Roles.Select(r => roles.Single(e => r.RoleId == e.Id).Name);
			var model = new RoleEditViewModel
			{
				User = new UserViewModel { Id = id, Name = user.UserName, Roles = userRoles },
				Roles = roles.Select(r => r.Name)

			};
			return View(model);
		}


	}
}