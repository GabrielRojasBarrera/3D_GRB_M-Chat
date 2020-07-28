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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using BCrypt.Net;

namespace M_Chat.UI.Pages.Home
{
    public class LoginModel : PageModel
    {
        private readonly M_Chat.Services.AppDBContext _context;
                
        public LoginModel(M_Chat.Services.AppDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Tutor Tutor { get; set; }
        


        public IActionResult OnPost()
        {
            
            var _tutor = login(Tutor.Email , Tutor.Contraseña);
            if (_tutor == null)
            {

                return Page();
            }
            else
            {                
                return Redirect("~/HomePage/DetailsUser?id=" + _tutor.TutorId);
            }
        }
        private Tutor login(string email, string contraseña)
        {           
            var tuTor = _context.Tutor.SingleOrDefault(a => a.Email.Equals(email));
           
            if (tuTor != null)
            {
                if (BCrypt.Net.BCrypt.Verify( contraseña, tuTor.Contraseña))
                {

                    return tuTor;
                }

            }
            return null;
        }
       
    }
}