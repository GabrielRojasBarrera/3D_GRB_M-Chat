using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;
using M_Chat.Services;


namespace M_Chat.UI.Pages.Home
{
    public class LoginModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public LoginModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        public Tutor Tutor { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tutor = await _context.Tutor.FirstOrDefaultAsync(m => m.Email == id);

            if (Tutor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}