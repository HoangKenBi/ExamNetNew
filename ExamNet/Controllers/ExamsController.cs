using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamNet.entities;
using PExamNet.entities;

namespace ExamNet.Controllers
{
    public class ExamsController : Controller
    {
        private readonly DataContext _context;

        public ExamsController(DataContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.exams.Include(e => e.Class).Include(e => e.Faculty).Include(e => e.Subject);
            return View(await dataContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.exams == null)
            {
                return NotFound();
            }

            var exam = await _context.exams
                .Include(e => e.Class)
                .Include(e => e.Faculty)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.classes, "Id", "Id");
            ViewData["FacultyId"] = new SelectList(_context.faculty, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.subject, "Id", "Id");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,ExamDate,ExamDuration,ClassId,SubjectId,FacultyId,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.classes, "Id", "Id", exam.ClassId);
            ViewData["FacultyId"] = new SelectList(_context.faculty, "Id", "Id", exam.FacultyId);
            ViewData["SubjectId"] = new SelectList(_context.subject, "Id", "Id", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.exams == null)
            {
                return NotFound();
            }

            var exam = await _context.exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.classes, "Id", "Id", exam.ClassId);
            ViewData["FacultyId"] = new SelectList(_context.faculty, "Id", "Id", exam.FacultyId);
            ViewData["SubjectId"] = new SelectList(_context.subject, "Id", "Id", exam.SubjectId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,ExamDate,ExamDuration,ClassId,SubjectId,FacultyId,Status")] Exam exam)
        {
            if (id != exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.Id))
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
            ViewData["ClassId"] = new SelectList(_context.classes, "Id", "Id", exam.ClassId);
            ViewData["FacultyId"] = new SelectList(_context.faculty, "Id", "Id", exam.FacultyId);
            ViewData["SubjectId"] = new SelectList(_context.subject, "Id", "Id", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.exams == null)
            {
                return NotFound();
            }

            var exam = await _context.exams
                .Include(e => e.Class)
                .Include(e => e.Faculty)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.exams == null)
            {
                return Problem("Entity set 'DataContext.exams'  is null.");
            }
            var exam = await _context.exams.FindAsync(id);
            if (exam != null)
            {
                _context.exams.Remove(exam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
          return (_context.exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
