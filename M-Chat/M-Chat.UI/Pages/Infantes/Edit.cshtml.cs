using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Infantes
{
    public class EditModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public EditModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Infante Infante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Infante = await _context.Infante
                .Include(i => i.Tutor).FirstOrDefaultAsync(m => m.InfanteId == id);

            if (Infante == null)
            {
                return NotFound();
            }
           ViewData["TutorId"] = new SelectList(_context.Tutor, "TutorId", "Apellido");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Infante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfanteExists(Infante.InfanteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InfanteExists(int id)
        {
            return _context.Infante.Any(e => e.InfanteId == id);
        }
    }
}
