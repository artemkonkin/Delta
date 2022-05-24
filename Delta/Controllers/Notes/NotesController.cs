using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContextLib;
using Delta.Controllers.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotesDomain;
using ServicesLib;
using UserDomain;

namespace Delta.Controllers.Notes
{
    public class NotesController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly NotesService _notesService;

        public NotesController(AppDbContext context, NotesService notesService, ILogger<HomeController> logger, UserManager<AppUser>? userManager) 
            : base(logger, userManager)
        {
            _context = context;
            _notesService = notesService;
        }

        // GET: Notes
        public IActionResult Index()
        {
            var userNotes = _notesService.GetUserNotes(CurrentUserId);
            return View(userNotes);
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NoteEntity == null)
            {
                return NotFound();
            }

            var noteEntity = await _context.NoteEntity
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noteEntity == null)
            {
                return NotFound();
            }

            return View(noteEntity);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text,UserId")] NoteEntity noteEntity)
        {
            if (ModelState.IsValid)
            {
                noteEntity.Id = Guid.NewGuid();
                _context.Add(noteEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", noteEntity.UserId);
            return View(noteEntity);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NoteEntity == null)
            {
                return NotFound();
            }

            var noteEntity = await _context.NoteEntity.FindAsync(id);
            if (noteEntity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", noteEntity.UserId);
            return View(noteEntity);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Text,UserId")] NoteEntity noteEntity)
        {
            if (id != noteEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noteEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteEntityExists(noteEntity.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", noteEntity.UserId);
            return View(noteEntity);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NoteEntity == null)
            {
                return NotFound();
            }

            var noteEntity = await _context.NoteEntity
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noteEntity == null)
            {
                return NotFound();
            }

            return View(noteEntity);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NoteEntity == null)
            {
                return Problem("Entity set 'AppDbContext.NoteEntity'  is null.");
            }
            var noteEntity = await _context.NoteEntity.FindAsync(id);
            if (noteEntity != null)
            {
                _context.NoteEntity.Remove(noteEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteEntityExists(Guid id)
        {
          return (_context.NoteEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
