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
    public class IndexModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;

        public IndexModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }

        

        public IList<Centro_educativo> Centro_educativo { get;set; }

        public async Task OnGetAsync()
        {
            Centro_educativo = await _context.Centro_Educativo.ToListAsync();
        }
    }
}
