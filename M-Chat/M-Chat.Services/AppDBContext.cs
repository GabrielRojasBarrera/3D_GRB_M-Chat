using M_Chat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace M_Chat.Services
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }

        public DbSet<Infante> Infante { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Centro_educativo>  Centro_Educativo { get; set; }
        public DbSet<Cuestionario> Cuestionario { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<Preguntas> Preguntas { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }
    }
}
