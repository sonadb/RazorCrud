﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Model;

namespace RazorCrud.Pages.Stuedents
{
    public class DeleteModel : PageModel
    {
        private readonly RazorCrud.Data.RazorCrudContext _context;

        public DeleteModel(RazorCrud.Data.RazorCrudContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);

            if (student != null)
            {
                Student = student;
                _context.Student.Remove(Student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
