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
    public class TweetController : Controller
    {
        [AcceptVerbs("Get", "Post")]
        public IActionResult CreatePost(string text)
        {
            if (text.Length >= 400)
            {
                return Json($"This text is too much more than 400 chars is already in use.");
            }
            return Json(true);
        }



        private readonly Milestone_1IdentityDbContext _context;

        public TweetController(Milestone_1IdentityDbContext context)
        {
            _context = context;
        }

        // GET: Tweet
        public async Task<IActionResult> Index()
        {
            var twitterContext = _context.tweets.Include(t => t.Group).Include(t => t.UserData);
            return View(await twitterContext.ToListAsync());
        }

        // GET: Tweet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tweets = await _context.tweets
                .Include(t => t.Group)
                .Include(t => t.UserData)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tweets == null)
            {
                return NotFound();
            }

            return View(tweets);
        }

        // GET: Tweet/Create
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId");
            ViewData["UserDataForeignKey"] = new SelectList(_context.users, "UserDataId", "UserDataId");
            return View();
        }

        // POST: Tweet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,UserDataForeignKey,tweetText,post_date,GroupForeignKey")] Tweets tweets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tweets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId", tweets.GroupForeignKey);
            ViewData["UserDataForeignKey"] = new SelectList(_context.users, "UserDataId", "UserDataId", tweets.UserDataForeignKey);
            return View(tweets);
        }

        // GET: Tweet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tweets = await _context.tweets.FindAsync(id);
            if (tweets == null)
            {
                return NotFound();
            }
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId", tweets.GroupForeignKey);
            ViewData["UserDataForeignKey"] = new SelectList(_context.users, "UserDataId", "UserDataId", tweets.UserDataForeignKey);
            return View(tweets);
        }

        // POST: Tweet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,UserDataForeignKey,tweetText,post_date,GroupForeignKey")] Tweets tweets)
        {
            if (id != tweets.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tweets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TweetsExists(tweets.id))
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
            ViewData["GroupForeignKey"] = new SelectList(_context.groups, "GroupId", "GroupId", tweets.GroupForeignKey);
            ViewData["UserDataForeignKey"] = new SelectList(_context.users, "UserDataId", "UserDataId", tweets.UserDataForeignKey);
            return View(tweets);
        }

        // GET: Tweet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tweets = await _context.tweets
                .Include(t => t.Group)
                .Include(t => t.UserData)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tweets == null)
            {
                return NotFound();
            }

            return View(tweets);
        }

        // POST: Tweet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tweets = await _context.tweets.FindAsync(id);
            _context.tweets.Remove(tweets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TweetsExists(int id)
        {
            return _context.tweets.Any(e => e.id == id);
        }
    }
}
