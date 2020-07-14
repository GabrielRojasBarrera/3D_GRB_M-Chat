using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using System.Text;

namespace M_Chat.Models
{
    public class Diagnostico
    {
        [Key]
        public int DiagnosticoId { get; set; }
        [Required]
        public string Resultado { get; set; }

        //Referencias
        [ForeignKey("Infante")]
        public int InfanteId { get; set; }
        public Infante Infante { get; set; }
        
        [ForeignKey("Cuestionario")]
        public int CuestionarioId { get; set; }
        public Cuestionario Cuestionario { get; set; }


    }
}
