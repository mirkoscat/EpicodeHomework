using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaWebApp.Models
{
	public class UserViewModel {
        public string Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<string>	Roles { get; set; } = Enumerable.Empty<string>();

	}
	public class RolesIndexviewModel
	{
		
		public IEnumerable<UserViewModel> Users { get; set; } = Enumerable.Empty<UserViewModel>();

	}
}