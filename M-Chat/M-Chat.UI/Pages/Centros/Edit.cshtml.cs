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

namespace M_Chat.UI.Pages.Centros
{
    public class EditModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public EditModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Centro_educativo Centro_educativo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Centro_educativo = await _context.Centro_Educativo.FirstOrDefaultAsync(m => m.CentroId == id);

            if (Centro_educativo == null)
            {
                return NotFound();
            }
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

            _context.Attach(Centro_educativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Centro_educativoExists(Centro_educativo.CentroId))
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

        private bool Centro_educativoExists(int id)
        {
            return _context.Centro_Educativo.Any(e => e.CentroId == id);
        }
    }
}
