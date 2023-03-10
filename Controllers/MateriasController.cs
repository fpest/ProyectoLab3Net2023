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

public class MateriasController : ControllerBase
{
    private readonly DataContext context;
     private readonly IConfiguration config;
    public MateriasController(DataContext dataContext, IConfiguration config)
        {
            
            
            
            this.context = dataContext;
            this.config = config;
        }
       


        [HttpPost("pedidoInscripcionMaterias")]
		public IActionResult pedidoInscripcionMaterias(String materia, String estado, String ciclolectivo)
		{
           

            try
            {
                var id = int.Parse(User.Identity.Name);
                
    
                var mate = context.Materia
                .Include(c => c.carrera)
                .Where(x => x.descripcion == materia && x.carrera.ciclolectivo.ToString() == ciclolectivo).First();


                var i = context.Database.ExecuteSqlRaw("DELETE FROM inscripcionm WHERE personaid = " + id + " and materiaid = " + mate.id);
                context.SaveChanges();



                Inscripcionm inscnueva= new Inscripcionm();

                
                inscnueva.materiaid = mate.id;
                inscnueva.estado="Pendiente";
                inscnueva.personaid= id;
                inscnueva.fechahora = DateTime.Now;


                var p1 = context.Inscripcionm.Add(inscnueva);
                context.SaveChanges();

                    
			

                return Ok(inscnueva);
    
    		}
			catch(Exception e)
            {
                return BadRequest(e.Message);
            }
    
			}
// Hasta aqui










        [HttpGet("ListarMaterias")]
        // Get Materias
		public async Task<IActionResult> ListarMaterias()
		{
            try
            {

            var id = int.Parse(User.Identity.Name);

   
      var i = context.MisMateriasView.FromSqlRaw<MisMateriasView>("SELECT DISTINCT mat.id, carr.ciclolectivo AS ciclolectivo, mat.descripcion As descripcion, inscm.estado as estado FROM `materia` mat Join inscripcionm inscm on mat.id = inscm.materiaid join carrera carr on carr.id = mat.carreraid join inscripcionc inscc on carr.id = inscc.carreraid where inscm.personaid = "+ id +" and inscc.estado='Vigente' and inscc.personaid = "+ id +""); 

                        
                        
                        
                        
                        			
			   
			   return Ok(i);//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
		
        }



        }



