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

public class CuentacorrienteController : ControllerBase
{
    private readonly DataContext context;
     private readonly IConfiguration config;
    public CuentacorrienteController(DataContext dataContext, IConfiguration config)
        {
            
            
            
            this.context = dataContext;
            this.config = config;
        }
       



        [HttpGet("ListarPagos")]
        // Get Materias
		public async Task<IActionResult> ListarPagos()
		{
            try
            {

            var id = int.Parse(User.Identity.Name);

              // var i = context.Materia;
               
			  //  var i = context.Materia
              //  .Include(carr => carr.carrera);
			   
 
			var i = from cuentacorriente in context.Cuentacorriente
				    where cuentacorriente.personaid == id orderby cuentacorriente.fechahora descending
               		select new {
						monto = cuentacorriente.monto,
                        fechahora = cuentacorriente.fechahora.ToString("dd/MM/yyyy"),
                        descripcion = cuentacorriente.descripcion			};
                        


			   
			   
			   
			   return Ok(i);//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
		
        }



        }



