
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoPropioLab3.Models;

namespace ProyectoPropioLab3.Controllers;

    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
 
        }
     
    //public DbSet<Propietario> Propietario { get; set; }
    public DbSet<Persona> Persona { get; set; }
       public DbSet<Materia> Materia { get; set; }
       public DbSet<Carrera> Carrera { get; set; }

       public DbSet<Inscripcionm> Inscripcionm { get; set; }

        public DbSet<Registronotas> Registronotas { get; set; }
         public DbSet<Cuentacorriente> Cuentacorriente { get; set; }
 
    }

