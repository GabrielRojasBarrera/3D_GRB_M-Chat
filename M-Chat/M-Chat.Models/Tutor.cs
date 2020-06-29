using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M_Chat.Models
{
    public class Tutor
    {
        [Key]
        [EmailAddress]
        [Required(ErrorMessage ="Su Email es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Su Contraseña es requerido")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        public string  Genero { get; set; }
        [Required(ErrorMessage = "Su Nombre es requerido")]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Curp { get; set; }
        
       

        //Referencias
      
        public List<Infante> Infantes { get; set; }

        public List<Respuestas> Respuestas { get; set; }



    }
}
