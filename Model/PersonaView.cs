using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropioLab3.Models
{
 
	 
	public class PersonaView
    {
public PersonaView(){}

public PersonaView(Persona p)
{
	this.id = p.id;
	this.nombre = p.nombre;
	this.apellido = p.apellido;
	this.dni = p.dni;
	this.email = p.email;
	this.pass = p.pass;
	this.rol = p.rol;
	this.token = p.token;

}

         [Key]
        [Display(Name = "Código")]
        public int id { get; set; }
		[Required]
		public string nombre { get; set; }
		[Required]
		public string apellido { get; set; }
		[Required]
		public string dni { get; set; }
		public string email { get; set; }
		[Required]
		public string pass { get; set; }
		public string rol { get; set; }
		public string token { get; set; }
		


		


	    public override string ToString()
    {
        return apellido + ", " + nombre;
    }




	}
	
	
}
