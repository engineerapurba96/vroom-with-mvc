﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vroom_with_mvc.AppDbContext;
using vroom_with_mvc.Models;

namespace vroom_with_mvc.Controllers
{
    public class PracxticeController : Controller
    {
        private readonly VroomDbContext _context;

        public PracxticeController(VroomDbContext context)
        {
            _context = context;
        }

        // GET: Pracxtice
        public async Task<IActionResult> Index()
        {
            int a = 10;
              return _context.Makes != null ? 
                          View(await _context.Makes.ToListAsync()) :
                          Problem("Entity set 'VroomDbContext.Makes'  is null.");
        }

        // GET: Pracxtice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Makes == null)
            {
                return NotFound();
            }

            var make = await _context.Makes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // GET: Pracxtice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pracxtice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Make make)
        {
            if (ModelState.IsValid)
            {
                _context.Add(make);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        // GET: Pracxtice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Makes == null)
            {
                return NotFound();
            }

            var make = await _context.Makes.FindAsync(id);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        // POST: Pracxtice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Make make)
        {
            if (id != make.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(make);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakeExists(make.Id))
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
            return View(make);
        }

        // GET: Pracxtice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Makes == null)
            {
                return NotFound();
            }

            var make = await _context.Makes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Pracxtice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Makes == null)
            {
                return Problem("Entity set 'VroomDbContext.Makes'  is null.");
            }
            var make = await _context.Makes.FindAsync(id);
            if (make != null)
            {
                _context.Makes.Remove(make);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakeExists(int id)
        {
          return (_context.Makes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
