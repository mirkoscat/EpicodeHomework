using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaWebApp.Models
{
	public class RoleEditViewModel
	{
		public UserViewModel User { get; set; }
		public IEnumerable<string> Roles { get; set; }=Enumerable.Empty<string>();
	}
}