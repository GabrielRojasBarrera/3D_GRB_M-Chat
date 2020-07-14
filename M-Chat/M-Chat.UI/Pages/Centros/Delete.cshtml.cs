using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Centros
{
    public class DeleteModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public DeleteModel(M_Chat.Services.AppDBContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Centro_educativo = await _context.Centro_Educativo.FindAsync(id);

            if (Centro_educativo != null)
            {
                _context.Centro_Educativo.Remove(Centro_educativo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
