using AspNetCore.Identity.Mongo.Collections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using netcore2_mongodb.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore2_mongodb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        readonly IIdentityUserCollection<ApplicationUser> _userUserCollection;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IIdentityUserCollection<ApplicationUser> userCollection)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userUserCollection = userCollection;
        }

        public ActionResult Index(string id) => View(_userManager.Users);

        public async Task<ActionResult> AddToRole(string roleName, string userName)
        {
            var u = await _userManager.FindByNameAsync(userName);

            if (!await _roleManager.RoleExistsAsync(roleName))
                await _roleManager.CreateAsync(new ApplicationRole(roleName));

            if (u == null) return NotFound();

            await _userManager.AddToRoleAsync(u, roleName);

            return Redirect($"/user/edit/{userName}");
        }

        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByNameAsync(id);

            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser user)
        {
            await _userUserCollection.UpdateAsync(user);
            return Redirect("/user");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userUserCollection.FindByIdAsync(id);
            await _userUserCollection.DeleteAsync(user);
            return Redirect("/user");
        }
    }
}
