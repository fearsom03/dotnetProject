using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Milestone_1.Data;
using Milestone_1.models;

namespace Milestone_1.Controllers
{
    public class UserDataController : Controller
    {
        private readonly TwitterContext _context;

        public UserDataController(TwitterContext context)
        {
            _context = context;
        }

        // GET: UserData
        public async Task<IActionResult> Index()
        {
            var twitterContext = _context.userDatas.Include(u => u.User);
            return View(await twitterContext.ToListAsync());
        }

        // GET: UserData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userData = await _context.userDatas
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserDataId == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // GET: UserData/Create
        public IActionResult Create()
        {
            ViewData["UserForeignKey"] = new SelectList(_context.users, "id", "id");
            return View();
        }

        // POST: UserData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserDataId,UserForeignKey,name,surname,gender,country,city")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserForeignKey"] = new SelectList(_context.users, "id", "id", userData.UserForeignKey);
            return View(userData);
        }

        // GET: UserData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userData = await _context.userDatas.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }
            ViewData["UserForeignKey"] = new SelectList(_context.users, "id", "id", userData.UserForeignKey);
            return View(userData);
        }

        // POST: UserData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserDataId,UserForeignKey,name,surname,gender,country,city")] UserData userData)
        {
            if (id != userData.UserDataId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDataExists(userData.UserDataId))
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
            ViewData["UserForeignKey"] = new SelectList(_context.users, "id", "id", userData.UserForeignKey);
            return View(userData);
        }

        // GET: UserData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userData = await _context.userDatas
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserDataId == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // POST: UserData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userData = await _context.userDatas.FindAsync(id);
            _context.userDatas.Remove(userData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDataExists(int id)
        {
            return _context.userDatas.Any(e => e.UserDataId == id);
        }
    }
}
