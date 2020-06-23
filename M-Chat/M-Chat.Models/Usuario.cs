using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace M_Chat.Models
{
    public class Usuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [Required]
        public DateTime Fecha_Nacimiento { get; set; }

        public string  Genero { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
