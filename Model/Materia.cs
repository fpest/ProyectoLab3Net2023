using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropioLab3.Models
{
    public class Materia
    {
        [Key]
        [Display(Name = "Código")]
        public int id { get; set; }
		[Required]
		public string descripcion { get; set; }
		[Required]
        [ForeignKey(nameof(Carrera))]
		public int carreraid { get; set; }
        public Inscripcionm inscripcionm{get; set;}


       public Carrera carrera { get; set; }

      



     

       
       

	}
}
