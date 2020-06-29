using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M_Chat.Models
{
    public class Infante
    {
        [Key]
        public int Curp_Infante { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha_Nacimiento_Infante { get; set; }
        [Required]
        public string Genero_Infante { get; set; }
        
        //Referencias
        [ForeignKey("Tutor")]
        public string Email { get; set; }

        [ForeignKey("Centro educativo")]
        public string Clave { get; set; }

        public List<Diagnostico> Diagnosticos { get; set; }


    }
}
