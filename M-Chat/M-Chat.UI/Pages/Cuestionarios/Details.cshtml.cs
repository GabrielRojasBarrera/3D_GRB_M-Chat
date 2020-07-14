using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;

namespace M_Chat.UI.Pages.Cuestionarios
{
    public class DetailsModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public DetailsModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        public Cuestionario Cuestionario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cuestionario = await _context.Cuestionario.FirstOrDefaultAsync(m => m.CuestionarioId == id);

            if (Cuestionario == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
