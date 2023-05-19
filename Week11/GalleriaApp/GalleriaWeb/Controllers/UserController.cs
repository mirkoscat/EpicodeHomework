using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace CodiceFiscale.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _user;
   

        public UserController(UserManager<IdentityUser> user) {

            _user = user;
          
        }


        public IActionResult Index()
        {
            var user = _user.Users;
            return View(user);

        }
 

        public IActionResult EditUser(string id)
        {
            var user = _user.Users.FirstOrDefault(x => x.Id == id);
       
            return View(user);
        }

       
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string permission)
        {
            var user = _user.Users.FirstOrDefault(x => x.Id == id);
            await _user.AddToRoleAsync(user, permission);
            return RedirectToAction("EditUser", new { user.Id });
        }


        public async Task<IActionResult> DeleteUser(string id)
        {

            var user = _user.Users.FirstOrDefault(x => x.Id == id);
            await _user.DeleteAsync(user);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> RemoveRole(string role, string id)
        {

            var user = _user.Users.FirstOrDefault(x => x.Id == id);
            await _user.RemoveFromRoleAsync(user, role);

            return RedirectToAction("EditUser" ,new { id });
        }
    }



    
}

