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
    public class CommentController : Controller
    {
        private readonly Milestone_1IdentityDbContext _context;

        public CommentController(Milestone_1IdentityDbContext context)
        {
            _context = context;
        }

        // GET: Comment
        public async Task<IActionResult> Index()
        {
            var twitterContext = _context.comments.Include(c => c.Tweets).Include(c => c.UserData);
            return View(await twitterContext.ToListAsync());
        }

        // GET: Comment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.comments
                .Include(c => c.Tweets)
                .Include(c => c.UserData)
                .FirstOrDefaultAsync(m => m.id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comment/Create
        public IActionResult Create()
        {
            ViewData["TweetForeignKey"] = new SelectList(_context.tweets, "id", "id");
            ViewData["UserDataId"] = new SelectList(_context.users, "UserDataId", "UserDataId");
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,TweetForeignKey,UserDataId,commentText")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TweetForeignKey"] = new SelectList(_context.tweets, "id", "id", comment.TweetForeignKey);
            ViewData["UserDataId"] = new SelectList(_context.users, "UserDataId", "UserDataId", comment.UserDataId);
            return View(comment);
        }

        // GET: Comment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["TweetForeignKey"] = new SelectList(_context.tweets, "id", "id", comment.TweetForeignKey);
            ViewData["UserDataId"] = new SelectList(_context.users, "UserDataId", "UserDataId", comment.UserDataId);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,TweetForeignKey,UserDataId,commentText")] Comment comment)
        {
            if (id != comment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.id))
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
            ViewData["TweetForeignKey"] = new SelectList(_context.tweets, "id", "id", comment.TweetForeignKey);
            ViewData["UserDataId"] = new SelectList(_context.users, "UserDataId", "UserDataId", comment.UserDataId);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.comments
                .Include(c => c.Tweets)
                .Include(c => c.UserData)
                .FirstOrDefaultAsync(m => m.id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.comments.FindAsync(id);
            _context.comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.comments.Any(e => e.id == id);
        }
    }
}
