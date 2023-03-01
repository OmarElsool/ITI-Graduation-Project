using Airbnb.Models;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public RolesController(RoleManager<IdentityRole> _roleManager, UserManager<AppUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index), await roleManager.Roles.ToListAsync());

            var roleExists = await roleManager.RoleExistsAsync(model.Name);
            if (roleExists)
            {
                ModelState.AddModelError("Name", "Role Is Exist");
                return View(nameof(Index), await roleManager.Roles.ToListAsync());
            }
            await roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UserWithRoles()
        {
            var users = userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = userManager.GetRolesAsync(user).Result
            }).ToList();
            return View(users);
        }
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var roles = await roleManager.Roles.ToListAsync();
            var userRoles = new UserRolesViewModel()
            {
                UserId = userId,
                UserName = user.UserName,
                Roles = roles.Select(r => new RolesViewModel()
                {
                    RoleName = r.Name,
                    IsSelected = userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList()
            };

            return View(userRoles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                {
                    await userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await userManager.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction(nameof(UserWithRoles));
        }
        public ActionResult UserSearch(string? Email)
        {
            if (Email == null)
            {
                return RedirectToAction(nameof(UserWithRoles));
            }
            var users = userManager.Users.Where(u => u.Email.Contains(Email)).Take(10).Select(user => new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = userManager.GetRolesAsync(user).Result
            }).ToList();

            return View(nameof(UserWithRoles), users);
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            await roleManager.DeleteAsync(role);

            return Ok();
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await userManager.DeleteAsync(user);

            return Ok();
        }

    }
}
