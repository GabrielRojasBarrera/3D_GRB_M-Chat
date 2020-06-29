using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace M_Chat.Models
{
    public class Centro_educativo
    {
        [Key]
        public int Clave { get; set; }
        [Required]
        public string Nombre_CentroEducativo { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Nivel_Educativo { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Representante_Institucion { get; set; }

        //Referencias
        
        public List<Infante> Infantes { get; set; }

    }
}
