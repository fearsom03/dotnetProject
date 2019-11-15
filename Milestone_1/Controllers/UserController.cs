using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Milestone_1.Abstractions;
using Milestone_1.Data;
using Milestone_1.models;
using Milestone_1.Repository;

namespace Milestone_1.Controllers
{
    public class UserController : Controller
    {
        //private readonly TwitterContext _context;
        private Repo repository;

        //public UserController(TwitterContext context)
        //{
        //    _context = context;
        //}

        public UserController(Repo repository)
        {
            this.repository = repository;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await repository.GetUsers());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await repository.GetUserDetail(id);
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
                repository.AddUser(user);
                await repository.Save();
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

            var user = await repository.GetUserDataById(id);
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
                    repository.UpdateUser(user.id);
                    await repository.Save();
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

            var user = await repository.GetUserById(id);
            repository.DeleteUser(user);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await repository.GetUserById(id);
            repository.DeleteUser(user);
            await repository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            var user = repository.GetUserById(id);
            if (user == null) {
                return true;
            }
            else { return false; }
        }
    }
}
