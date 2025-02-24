using ChairEcommerce.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChairEcommerce.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> index()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> addRoles(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var myRole = await _userManager.GetRolesAsync(user);

            var AllRoles = await _roleManager.Roles.ToListAsync();

            if (AllRoles != null)
            {
                var roleList = AllRoles.Select(r => new RoleViewModel()
                {
                    RoleId = r.Id,
                    RoleName = r.Name,
                    useRole = myRole.Any(x => x == r.Name)
                });

                ViewBag.user = user.UserName;
                ViewBag.userid = user.Id;

                return View(roleList);
            }

            return RedirectToAction("index");

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> addRoles(string UserId, string jsonRoles)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            List<RoleViewModel> roles =
                JsonConvert.DeserializeObject<List<RoleViewModel>>(jsonRoles);

            if (roles != null)
            {

                var userRole = await _userManager.GetRolesAsync(user);

                foreach (var role in roles)
                {

                    if (userRole.Contains(role.RoleName.Trim()) && !role.useRole)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.RoleName.Trim());
                    }
                    else if (!userRole.Contains(role.RoleName.Trim()) && role.useRole)
                    {
                        await _userManager.AddToRoleAsync(user, role.RoleName.Trim());
                    }
                }
                return RedirectToAction("index");
            }

            return NotFound();

        }


    }
}
