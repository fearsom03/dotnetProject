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
    public class UserDataGroupController : Controller
    {
        private readonly TwitterContext _context;

        public UserDataGroupController(TwitterContext context)
        {
            _context = context;
        }

        // GET: UserDataGroup
        public async Task<IActionResult> Index()
        {
            var twitterContext = _context.userDataGroups.Include(u => u.Group).Include(u => u.UserData);
            return View(await twitterContext.ToListAsync());
        }

        // GET: UserDataGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDataGroup = await _context.userDataGroups
                .Include(u => u.Group)
                .Include(u => u.UserData)
                .FirstOrDefaultAsync(m => m.UserDataForeignKey == id);
            if (userDataGroup == null)
            {
                return NotFound();
            }

            return View(userDataGroup);
        }

        // GET: UserDataGroup/Create
        public IActionResult Create()
        {
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId");
            ViewData["UserDataForeignKey"] = new SelectList(_context.userDatas, "UserDataId", "UserDataId");
            return View();
        }

        // POST: UserDataGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserDataForeignKey,GroupForeignKey")] UserDataGroup userDataGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDataGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId", userDataGroup.GroupForeignKey);
            ViewData["UserDataForeignKey"] = new SelectList(_context.userDatas, "UserDataId", "UserDataId", userDataGroup.UserDataForeignKey);
            return View(userDataGroup);
        }

        // GET: UserDataGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDataGroup = await _context.userDataGroups.FindAsync(id);
            if (userDataGroup == null)
            {
                return NotFound();
            }
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId", userDataGroup.GroupForeignKey);
            ViewData["UserDataForeignKey"] = new SelectList(_context.userDatas, "UserDataId", "UserDataId", userDataGroup.UserDataForeignKey);
            return View(userDataGroup);
        }

        // POST: UserDataGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserDataForeignKey,GroupForeignKey")] UserDataGroup userDataGroup)
        {
            if (id != userDataGroup.UserDataForeignKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDataGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDataGroupExists(userDataGroup.UserDataForeignKey))
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
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId", userDataGroup.GroupForeignKey);
            ViewData["UserDataForeignKey"] = new SelectList(_context.userDatas, "UserDataId", "UserDataId", userDataGroup.UserDataForeignKey);
            return View(userDataGroup);
        }

        // GET: UserDataGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDataGroup = await _context.userDataGroups
                .Include(u => u.Group)
                .Include(u => u.UserData)
                .FirstOrDefaultAsync(m => m.UserDataForeignKey == id);
            if (userDataGroup == null)
            {
                return NotFound();
            }

            return View(userDataGroup);
        }

        // POST: UserDataGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDataGroup = await _context.userDataGroups.FindAsync(id);
            _context.userDataGroups.Remove(userDataGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDataGroupExists(int id)
        {
            return _context.userDataGroups.Any(e => e.UserDataForeignKey == id);
        }
    }
}
