using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Milestone_1.Areas.Identity.Data;
using Milestone_1.Data;
using Milestone_1.models;

namespace Milestone_1.Controllers
{
    [Authorize]
    public class FollowerController : Controller
    {
        private readonly Milestone_1IdentityDbContext _context;

        public FollowerController(Milestone_1IdentityDbContext context)
        {
            _context = context;
        }

        // GET: Follower
        public async Task<IActionResult> Index()
        {
            var twitterContext = _context.followers.Include(f => f.UserToFollow);
            return View(await twitterContext.ToListAsync());
        }

        // GET: Follower/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followers = await _context.followers
                .Include(f => f.UserToFollow)
                .FirstOrDefaultAsync(m => m.id == id);
            if (followers == null)
            {
                return NotFound();
            }

            return View(followers);
        }

        // GET: Follower/Create
        public IActionResult Create()
        {
            ViewData["UserToFollowForeignKey"] = new SelectList(_context.users, "id", "id");
            return View();
        }

        // POST: Follower/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,UserToFollowForeignKey")] Followers followers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserToFollowForeignKey"] = new SelectList(_context.users, "id", "id", followers.UserToFollowForeignKey);
            return View(followers);
        }

        // GET: Follower/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followers = await _context.followers.FindAsync(id);
            if (followers == null)
            {
                return NotFound();
            }
            ViewData["UserToFollowForeignKey"] = new SelectList(_context.users, "id", "id", followers.UserToFollowForeignKey);
            return View(followers);
        }

        // POST: Follower/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,UserToFollowForeignKey")] Followers followers)
        {
            if (id != followers.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowersExists(followers.id))
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
            ViewData["UserToFollowForeignKey"] = new SelectList(_context.users, "id", "id", followers.UserToFollowForeignKey);
            return View(followers);
        }

        // GET: Follower/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followers = await _context.followers
                .Include(f => f.UserToFollow)
                .FirstOrDefaultAsync(m => m.id == id);
            if (followers == null)
            {
                return NotFound();
            }

            return View(followers);
        }

        // POST: Follower/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followers = await _context.followers.FindAsync(id);
            _context.followers.Remove(followers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowersExists(int id)
        {
            return _context.followers.Any(e => e.id == id);
        }
    }
}
