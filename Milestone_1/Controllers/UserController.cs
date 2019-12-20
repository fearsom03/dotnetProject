using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Milestone_1.models;
using Milestone_1.Services;

namespace Milestone_1.Controllers
{
    [Authorize (Roles ="Admin")]
    public class UserController : Controller
    {
        //private readonly TwitterContext _context;
        private UserDataService service;
        private readonly UserManager<IdentityUser> _userManager;
        [TempData]
        public string Message { get; set; }


        public UserController(UserDataService repository , UserManager<IdentityUser> userManager)
        {
            this.service = repository;
            this._userManager = userManager;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("count")))
            {
                HttpContext.Session.SetString("msg", "authenticated");
            }
            Message = $"You're {HttpContext.Session.GetString("msg")} user";
            return View(await service.GetUsersIdentity());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await service.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,login,password")] User user)
        {
            if (ModelState.IsValid)
            {
                await service.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await service.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }



        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,login,password")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateUser(user.id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await service.GetUserById(id);
            await service.DeleteUser(user);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await service.GetUserById(id);
            await service.DeleteUser(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            var user = service.GetUserById(id);
            if (user == null) {
                return true;
            }
            else { return false; }
        }
    }
}
