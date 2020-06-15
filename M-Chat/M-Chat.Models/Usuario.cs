using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace M_Chat.Models
{
    public class Usuario
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contraseña { get; set; }
        [Required]
        public DateTime Fecha_Nacimiento { get; set; }

        public string  Genero { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
