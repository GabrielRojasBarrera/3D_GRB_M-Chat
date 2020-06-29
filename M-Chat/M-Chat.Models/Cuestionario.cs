using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Text;

namespace M_Chat.Models
{
    public class Cuestionario
    {
        [Key]
        public int id_Cuestionario { get; set; }
        [Required]
        public String Descripccion { get; set; }
        [Required]
        public DateTime Fecha_aplicacion { get; set; }

        public List<Preguntas> Preguntas { get; set; }

    }
}
