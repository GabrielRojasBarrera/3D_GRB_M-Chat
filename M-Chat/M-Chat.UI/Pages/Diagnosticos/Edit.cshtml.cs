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

namespace M_Chat.UI.Pages.Diagnosticos
{
    public class EditModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public EditModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Diagnostico Diagnostico { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diagnostico = await _context.Diagnostico
                .Include(d => d.Cuestionario)
                .Include(d => d.Infante).FirstOrDefaultAsync(m => m.DiagnosticoId == id);

            if (Diagnostico == null)
            {
                return NotFound();
            }
           ViewData["CuestionarioId"] = new SelectList(_context.Cuestionario, "CuestionarioId", "CuestionarioId");
           ViewData["InfanteId"] = new SelectList(_context.Infante, "InfanteId", "Apellido");
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

            _context.Attach(Diagnostico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosticoExists(Diagnostico.DiagnosticoId))
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

        private bool DiagnosticoExists(int id)
        {
            return _context.Diagnostico.Any(e => e.DiagnosticoId == id);
        }
    }
}
