using MailKit.Net.Smtp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using ProyectoPropioLab3.Models;

namespace ProyectoPropioLab3.Controllers;

[ApiController]
[Route("[controller]")]
//Para autorizar
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class CarrerasController : ControllerBase
{
    private readonly DataContext context;
     private readonly IConfiguration config;
    public CarrerasController(DataContext dataContext, IConfiguration config)
        {
            
            
            
            this.context = dataContext;
            this.config = config;
        }
       

        //pedidoInscripcion

        [HttpPost("pedidoInscripcion")]
		public IActionResult pedidoInscripcion(String carrera, String estado, String ciclolectivo)
		{
           

            try
            {
                var id = int.Parse(User.Identity.Name);
                
    
                var carre = context.Carrera
                .Where(x => x.descripcion == carrera && x.ciclolectivo.ToString() == ciclolectivo).First();


                var i = context.Database.ExecuteSqlRaw("DELETE FROM inscripcionc WHERE personaid = " + id + " and carreraid = " + carre.id);
                context.SaveChanges();



                Inscripcionc inscnueva= new Inscripcionc();

                
                inscnueva.carreraid = carre.id;
                inscnueva.estado="Pendiente";
                inscnueva.personaid= id;
                inscnueva.fechahora = DateTime.Now;


                var p1 = context.Inscripcionc.Add(inscnueva);
                context.SaveChanges();

                    
			

                return Ok(inscnueva);
    
    		}
			catch(Exception e)
            {
                return BadRequest(e.Message);
            }
    
			}


        [HttpGet("ListarCarreras")]
        // Get Materias
		public async Task<IActionResult> ListarCarreras()
		{
            try
            {

            var id = int.Parse(User.Identity.Name);


         
  	   var i = from carre in context.Carrera
					join inscripcionc in context.Inscripcionc on carre.id equals inscripcionc.carreraid
                    where inscripcionc.personaid == id
               		select new {
						ciclolectivo = carre.ciclolectivo,
						descripcion = carre.descripcion,
						estado = inscripcionc.estado					};
			


  			   
			   return Ok(i);//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
		
        }



        }



