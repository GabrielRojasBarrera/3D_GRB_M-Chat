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

namespace M_Chat.UI.Pages.Pregunta
{
    public class EditModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public EditModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Preguntas Preguntas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Preguntas = await _context.Preguntas
                .Include(p => p.Cuestionario).FirstOrDefaultAsync(m => m.PreguntaId == id);

            if (Preguntas == null)
            {
                return NotFound();
            }
           ViewData["CuestionarioId"] = new SelectList(_context.Cuestionario, "CuestionarioId", "CuestionarioId");
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

            _context.Attach(Preguntas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasExists(Preguntas.PreguntaId))
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

        private bool PreguntasExists(int id)
        {
            return _context.Preguntas.Any(e => e.PreguntaId == id);
        }
    }
}
