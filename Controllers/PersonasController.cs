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
using MySqlConnector;

namespace ProyectoPropioLab3.Controllers;

[ApiController]
[Route("[controller]")]
//Para autorizar
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class PersonasController : ControllerBase
{
    private readonly DataContext context;
     private readonly IConfiguration config;
    public PersonasController(DataContext dataContext, IConfiguration config)
        {
            this.context = dataContext;
            this.config = config;
        }

//actualizarClave

[HttpPost("actualizarClave")]
		public IActionResult actualizarClave([FromBody] Clave clave)
		{
           

            try
            {
                var id = int.Parse(User.Identity.Name);
				Persona p = context.Persona.Find(id);

				string hashedActual = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: clave.passwordActual,
					salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
					prf: KeyDerivationPrf.HMACSHA1,
					iterationCount: 1000,
					numBytesRequested: 256 / 8));
				
				string hashedNueva = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: clave.passwordNueva1,
					salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
					prf: KeyDerivationPrf.HMACSHA1,
					iterationCount: 1000,
					numBytesRequested: 256 / 8));
				
				
                if (hashedActual == p.pass){

					p.pass = hashedNueva;
        			var p1 = context.Persona.Update(p);
        			context.SaveChanges();
					String mensaje = "Clave Actualizada Correctamente.";
					clave.mensaje = mensaje;
                	return Ok(clave);
				}
				else{
					String mensaje = "No se pudo actualizar el Password. Verifique los datos ingresados.";
					clave.mensaje = mensaje;
					return Ok(clave);
				}

				

			}
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
    
			}

//preparadoBase


        [HttpGet("preparadoBase")]
		public IActionResult preparadoBase()
		{
			
		var id = int.Parse(User.Identity.Name);
		
            try
            {

//Prepara Carreras    	
		List<Inscripcionc> insc = context.Inscripcionc
			.Where(x=>x.personaid == id).ToList();
		
		List<Carrera> carre = context.Carrera.ToList();
		
		foreach (Carrera car in carre)
		{
	    var inscrinueva = new Inscripcionc();
		
		inscrinueva.carreraid = car.id;
		inscrinueva.personaid = id;
		inscrinueva.estado = "Disponible";
		inscrinueva.fechahora = Convert.ToDateTime("2023-01-01");

		context.Inscripcionc.Add(inscrinueva);

		}
		context.SaveChanges();


foreach(Inscripcionc inscri in insc){

		var inscrinuevados = new Inscripcionc();
		inscrinuevados.carreraid = inscri.carreraid;
		inscrinuevados.personaid = inscri.personaid;
		inscrinuevados.estado = inscri.estado;
		inscrinuevados.fechahora = inscri.fechahora;//Convert.ToDateTime("2023-01-01");

		context.Inscripcionc.Add(inscrinuevados);
}
context.SaveChanges();
// Hasta aqui prepara carreras
//Prepara Materias

		List<Inscripcionm> insm = context.Inscripcionm
			.Where(x=>x.personaid == id).ToList();
		
		List<Materia> mate = context.Materia.ToList();
		
		foreach (Materia mat in mate)
		{
	    var inscrinueva = new Inscripcionm();
		
		inscrinueva.materiaid = mat.id;
		inscrinueva.personaid = id;
		inscrinueva.estado = "Disponible";
		inscrinueva.fechahora = Convert.ToDateTime("2023-01-01");

		context.Inscripcionm.Add(inscrinueva);

		}
		context.SaveChanges();


foreach(Inscripcionm inscri in insm){

		var inscrinuevados = new Inscripcionm();
		inscrinuevados.materiaid = inscri.materiaid;
		inscrinuevados.personaid = inscri.personaid;
		inscrinuevados.estado = inscri.estado;
		inscrinuevados.fechahora = inscri.fechahora;//Convert.ToDateTime("2023-01-01");

		context.Inscripcionm.Add(inscrinuevados);
}
context.SaveChanges();








// Hasta aqui prepara materias



                return Ok("sss");//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
    
        }

//preparadoBase










        [HttpGet("actualizarTokenFirebase")]
		public IActionResult actualizarTokenFirebase(String TokenFirebase)
		{
			
		var id = int.Parse(User.Identity.Name);
		var p = context.Persona.Find(id);
            try
            {
                p.token = TokenFirebase;
        		var p1 = context.Persona.Update(p);
  		
		context.SaveChanges();
                return Ok("sss");//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
    
        }







        [HttpPost("actualizarPerfil")]
		public IActionResult actualizarPerfil(String nombre, String apellido, String dni, String email)
		{
		var id = int.Parse(User.Identity.Name);
        Persona p = context.Persona.Find(id);
		
		p.nombre = nombre;
		p.apellido = apellido;
		p.dni = dni;
		p.email = email;
		




		    try
            {
                
        var p1 = context.Persona.Update(p);
        context.SaveChanges();
                return Ok("sss");//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
    
        }




        [HttpGet("obtenerPerfil")]
        // Get Persona Logueada
		public IActionResult obtenerPerfil()
		{
            
			var id = int.Parse(User.Identity.Name);
			try
            {
              
                Persona p = context.Persona.Find(id);
               
                return Ok(p);//
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
			
        }


		// POST api/<controller>/login
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] LoginView loginView)
		{
			try
			{
				string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: loginView.Clave,
					salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
					prf: KeyDerivationPrf.HMACSHA1,
					iterationCount: 1000,
					numBytesRequested: 256 / 8));
				var p = await context.Persona.FirstOrDefaultAsync(x => x.email == loginView.Usuario);
	
				if (p == null || p.pass != hashed)//p == null || p.Clave != hashed
	
				{
					return BadRequest("Nombre de usuario o clave incorrecta");
				}
				else
				{
					var key = new SymmetricSecurityKey(
						System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
					var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    
					var claims = new List<Claim>
					{
						//new Claim(ClaimTypes.Id, p.Id.ToString()),

						new Claim(ClaimTypes.Name, p.id.ToString())
				    };

					var token = new JwtSecurityToken(
						issuer: config["TokenAuthentication:Issuer"],
						audience: config["TokenAuthentication:Audience"],
						claims: claims,
						expires: DateTime.Now.AddMinutes(60),
						signingCredentials: credenciales
					);
					return Ok(new JwtSecurityTokenHandler().WriteToken(token));
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		// GET api/<controller>/5
		[HttpGet("token")]
		
 		public async Task<IActionResult> token()
		{
			try
			{	//este método si tiene autenticación, al entrar, generar clave aleatorio y enviarla por correo
				

				var id = int.Parse(User.Identity.Name);
                Persona original = context.Persona.Find(id);
				
				var perfil = new
				{
					email = original.email,
					nombre = original.nombre,
					rol = "Alumno"
				};

				
				Random rand        = new Random(Environment.TickCount);
				string randomChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
				string nuevaClave  = "";
				for (int i = 0; i < 8; i++)
				{
					nuevaClave += randomChars[rand.Next(0, randomChars.Length)];
				}
					
						String nuevaClaveSin = nuevaClave;

						//nuevaClave = "123";
				nuevaClave = Convert.ToBase64String(KeyDerivation.Pbkdf2(
							password: nuevaClave,
							salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
							prf: KeyDerivationPrf.HMACSHA1,
							iterationCount: 1000,
							numBytesRequested: 256 / 8));

				
				
				original.pass = nuevaClave;
				context.Persona.Update(original);	
				await context.SaveChangesAsync();	
				var message = new MimeKit.MimeMessage();
				message.To.Add(new MailboxAddress(perfil.nombre, perfil.email));
				message.From.Add(new MailboxAddress(perfil.nombre, perfil.email));
	
				message.Subject = "Nueva Password para la Aplicación del Instituto ESAC.";
				message.Body = new TextPart("html")
				{
					Text = @$"<h1>Hola</h1>
					<p>¡Bienvenido, {perfil.nombre} Clave {nuevaClaveSin}</p>",//Envio
				};
				message.Headers.Add("Encabezado", "Valor");//solo si hace falta
				MailKit.Net.Smtp.SmtpClient client = new SmtpClient();
				client.ServerCertificateValidationCallback = (object sender, 
					System.Security.Cryptography.X509Certificates.X509Certificate certificate, 
					System.Security.Cryptography.X509Certificates.X509Chain chain,
					System.Net.Security.SslPolicyErrors sslPolicyErrors) => { return true; };
				client.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.Auto);
				client.Authenticate(config["SMTPUser"], config["SMTPPass"]);//estas credenciales deben estar en el user secrets
				//client.Authenticate("ulp.api.net@gmail.com", "ktitieuikmuzcuup");
				await client.SendAsync(message);
				return Ok("Su Password fue restaurada.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



		// GET api/<controller>/5
		[HttpPost("emailPedido")]
		[AllowAnonymous]
		public async Task<IActionResult> emailPedido([FromBody] string email)
		{
			try
			{	


				var entidad1 = await context.Persona.FirstOrDefaultAsync(x => x.email == email);
				var entidad= new PersonaView(entidad1);
				var key = new SymmetricSecurityKey(
						System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
					var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
					var claims = new List<Claim>
					
					
					{
						new Claim(ClaimTypes.Name, entidad1.id.ToString()),
				    };


					var token = new JwtSecurityToken(
						issuer: config["TokenAuthentication:Issuer"],
						audience: config["TokenAuthentication:Audience"],
						claims: claims,
						expires: DateTime.Now.AddMinutes(600),
						signingCredentials: credenciales
					);
					var to = new JwtSecurityTokenHandler().WriteToken(token);
					//var direccion = "http://192.168.100.4:5000/Personas/token?access_token=" + to;
					var direccion = "http://192.168.56.1:5000/Personas/token?access_token=" + to;
					try
			{
				
	
				var message = new MimeKit.MimeMessage();
				message.To.Add(new MailboxAddress(entidad.nombre, entidad1.email));
				message.From.Add(new MailboxAddress(entidad.nombre, entidad1.email));
				message.Subject = "Reseteo de Password";
				message.Body = new TextPart("html")

				
				{
					Text = @$"<h1>Hola</h1>
					<p>Bienvenido, {entidad1.nombre}  <a href={direccion} >Restablecer</a> </p>",					
				};
				
				


				message.Headers.Add("Encabezado", "Valor");
				MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
				client.ServerCertificateValidationCallback = (object sender,
				System.Security.Cryptography.X509Certificates.X509Certificate certificate,
				System.Security.Cryptography.X509Certificates.X509Chain chain,
				System.Net.Security.SslPolicyErrors sslPolicyErrors) => { return true;};
				client.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.Auto);
			client.Authenticate(config["SMTPUser"], config["SMTPPass"]);
	//			client.Authenticate("ulp.api.net@gmail.com", "ktitieuikmuzcuup");

				await client.SendAsync(message);
				return Ok("ok");
			
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
				return entidad != null ? Ok(entidad) : NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}










/*

		// GET api/<controller>/5
		[HttpPost("email")]
		[AllowAnonymous]
		public async Task<IActionResult> GetByEmail([FromForm]string email)
		{
			try
			{	//método sin autenticar, busca el propietario xemail
				var entidad = await context.Propietario.FirstOrDefaultAsync(x => x.Email == email);
				//para hacer: si el propietario existe, mandarle un email con un enlace con el token
				//ese enlace servirá para resetear la contraseña
				return entidad != null ? Ok(entidad) : NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
*/

