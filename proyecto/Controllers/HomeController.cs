using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public UserModel usuarioConectado = null;
        public ListModel lstPersonas = new ListModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var dato = TempData["login"];
            return View();
        }

        public IActionResult Login()
        {
            return View();
        } public IActionResult Principal()
        {
            return View();
        }

        //[Authorize]//Solo se puede ingresar aquí con el login válido
        public IActionResult Personas()
        {
            var dato = TempData["login"];
            ViewData["Title"] = "Lista de Personas";
            var lista = new ListModel();
            var modelo = LeerTXT(); //lista.ListaPersonas();            
            //ARCHIVO Lee el txt
            
            return View(modelo);

        }


        //[Authorize]//Solo se puede ingresar aquí con el login válido
        [Route("DetallePersona/{id}")]
        public IActionResult DetallePersona(int id)
        {
            ViewData["Title"] = "Persona "+id;
            ViewData["Titulo"] = "Detalle de la persona N° " + id;
            var persona = lstPersonas.DetallePersona(LeerTXT(),id);
            return View(persona);
        }
        public IActionResult NuevaPersona()
        {
             ViewData["Title"] = "Nueva Persona";
            ViewData["Titulo"] = "Registrar nueva persona";
            return View();
        }


        public IActionResult Autenticar(string usuario, string clave)
        {
            //Datos en duro, acá se puede conectar a una BD
            UserModel DatosDelLogin = null;

            List<UserModel> listaUsuarios = new List<UserModel>(){
            new UserModel { usuario = "admin", clave = "admin", nombre="Administrador", email = "micorreo@gmail.com" },
            new UserModel{ usuario = "user1", clave="12345", nombre="Usuario de prueba",email = "user1@gmail.com" } };

            foreach (UserModel usu in listaUsuarios)
            {
                if (usu.usuario == usuario && usu.clave == clave)
                {
                    DatosDelLogin = usu; //Si el usuario y clave existen, se asignan todos sus valores.
                }
            }
            String token = ValidarLoginConJWT(DatosDelLogin);

            if (token == "ERROR" || token == "")
            {
                return Content("Datos incorrectos.");
            }
            else
            {
                TempData["login"] = token;
                return RedirectToAction("Principal", "Home", new { usuario = usuarioConectado.usuario,
                                                                    token = token });
            }
        }

        public String ValidarLoginConJWT(UserModel DatosDelLogin)
        {

            //Obtener la configuración del archivo appsetings.json
            IConfiguration _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            //Obtener el token
            String encodetoken = "";
            if (DatosDelLogin != null)
            {
                //Los Claims guardan información del usuario
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,DatosDelLogin.usuario),
                    new Claim(JwtRegisteredClaimNames.Email,DatosDelLogin.email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var algorithm = SecurityAlgorithms.HmacSha256;

                var signingCredentials = new SigningCredentials(key, algorithm);

                var token = new JwtSecurityToken(
                  issuer: _config["Jwt:Issuer"],
                  audience: _config["Jwt:Audiance"],
                  claims,
                  notBefore: DateTime.Now,
                  expires: DateTime.Now.AddMinutes(15),
                  signingCredentials: signingCredentials
                );

                encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
                usuarioConectado = DatosDelLogin; //cargar logueo correcto
                TempData["login"] = usuarioConectado.usuario;

                //return Ok(new { token_acceso = encodetoken });

                return (new { token_acceso = encodetoken }).ToString();

            }//Fin if usuario != null
            else
            {
                usuarioConectado = null;
                return "ERROR";
            }
        }

        //
        public String ValidarDatos(ListModel persona)
        {
            String mensaje = "";
            //Validar que los campos no deben de estar vacío y tampoco que tengan espacios en blanco
            mensaje += (!String.IsNullOrEmpty(persona.nombres)) ? "" : "Ingresar los nombres.\r\n";
            mensaje += (!String.IsNullOrEmpty(persona.apaterno)) ? "" : "Ingresar el apellido paterno.\r\n";
            mensaje += (!String.IsNullOrEmpty(persona.amaterno)) ? "" : "Ingresar el apellido materno.\r\n";
            mensaje += (!String.IsNullOrEmpty(persona.dni)) ? "" : "Ingresar el nombre de la persona.\r\n";
            mensaje += (!String.IsNullOrEmpty(persona.fechanac)) ? "" : "Ingresar la fecha de nacimiento.\r\n";
            mensaje += (!String.IsNullOrEmpty(persona.celular)) ? "" : "Ingresar el nombre de la persona";

            //Para el caso de las listas desplegables, se validará que todos estén seleccionados
            mensaje += (persona.sexo != "-SELECCIONE-") ? "" : "Seleccione el sexo.\r\n";
            mensaje += (persona.distrito != "-SELECCIONE-") ? "" : "Seleccione el distrito de residencia.\r\n";
            mensaje += (persona.estado != "-SELECCIONE-") ? "" : "Seleccione el estado del registro.\r\n";

            //validación de los números (dni y celular)
            int num;
            mensaje += (Int32.TryParse(persona.dni, out num)) ? "" : "El DNI solo debe contener números.\r\n";
            mensaje += (Int32.TryParse(persona.celular, out num)) ? "" : "El celular solo debe contener números.\r\n";

            //validación de los textos (solo letras con o sin tildes)
            mensaje += (!String.IsNullOrEmpty(persona.nombres)) && ValidarPalabra(persona.nombres) ? "" : "Los nombres solo pueden contener letras (a-z, A-z) con o sin tildes.\r\n";
            mensaje += (!String.IsNullOrEmpty(persona.apaterno)) && ValidarPalabra(persona.apaterno) ? "" : "El apellido paterno solo puede contener letras (a-z, A-z) con o sin tildes.\r\n";
            mensaje += (!String.IsNullOrEmpty(persona.amaterno)) && ValidarPalabra(persona.amaterno) ? "" : "El apellido materno solo puede contener letras (a-z, A-z) con o sin tildes.\r\n";

            //Si todo es correcto, el campo mensaje estaría vacío
            return mensaje;
        }

        public bool ValidarPalabra(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                //Lista para las tildes y las eñe (ñ y Ñ)
                List<int> tildes = new List<int>() { 160, 130, 161, 162, 163, 181, 144, 214, 224, 233, 164, 165 };
                //Campos en ASCII: A=65 Z=90 and a=97 z=122
                if (
                    (int)texto[i] < 65 || ((int)texto[i] > 90
                    &&
                    (int)texto[i] < 97) || (int)texto[i] > 122
                    &&
                    !tildes.Contains((int)texto[i])
                    )
                    return false;
            }
            return true;
        }

        public IActionResult GuardarPersona(ListModel persona)
        {
            List<ListModel> lstPer = new List<ListModel>();

            //((List<ListModel>)TempData["lstPersonas"])

            String resultado = ValidarDatos(persona);
            if (resultado == "")
            {                
                lstPer = LeerTXT();//lstPersonas.ListaPersonas();
                //verificar si existe
                int existe = -1;
                for(int i = 0 ; i < lstPer.Count; i++){
                    if(lstPer[i].id == persona.id)
                    {
                        existe = i;
                    }
                }
                if(existe >= 0)
                {
                    //Actualiza
                    lstPer[existe] = persona;

                }else
                {
                    persona.id = lstPer.Select(x=>x.id).Max()+1;
                    lstPer.Add(persona);
                }
                //ARCHIVO Guarda en un txt
                EscribirEnTXT(lstPer);
                

                //

                //return View(persona);
                return RedirectToAction("Personas", "Home");
            }
            else
            {
                return Content(resultado); //Abre un archivo en otro lugar
            }
        }


        //funciones para archivo de texto
        public List<ListModel> LeerTXT()
        {
            List<ListModel> modelo = new List<ListModel>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader("Lista.txt")) {
                string line;               
                while ((line = sr.ReadLine()) != null) {
                    Console.WriteLine(line);

                    modelo.Add(new ListModel(){   id = Convert.ToInt32(line.Split(";")[0].ToString()),
                                                    nombres = line.Split(";")[1],
                                                    apaterno=line.Split(";")[2], 
                                                    amaterno =line.Split(";")[3], 
                                                    dni=line.Split(";")[4], 
                                                    fechanac=line.Split(";")[5], 
                                                    sexo=line.Split(";")[6], 
                                                    distrito=line.Split(";")[7], 
                                                    celular=line.Split(";")[8], 
                                                    estado=line.Split(";")[9], 
                                                    fechacreacion=line.Split(";")[10]
                    });
                    modelo = modelo.OrderBy(a=> a.id).ToList();
                }
            }
            /*
            if(modelo.Count ==0 || modelo == null)
                modelo = (new ListModel()).ListaPersonas();
            */
            return modelo;
        }
        public void EscribirEnTXT(List<ListModel> lista)
        {
            using (System.IO.TextWriter tw = new System.IO.StreamWriter("Lista.txt"))
                    {
                        foreach (var i in lista)
                            tw.WriteLine(   i.id+";"+ i.nombres+";"+ i.apaterno+";"+
                                            i.amaterno+";"+ i.dni+";"+ i.fechanac+";"+ 
                                            i.sexo+";"+ i.distrito+";"+ i.celular+";"+
                                            i.estado+";"+ i.fechacreacion);
                    }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //pruebas unitarias
        public string Mensaje(){
            return "Hola mundo";
        }

        
        public bool UsuarioExiste(string usuario,string clave){
            List<UserModel> listaUsuarios = new List<UserModel>(){
            new UserModel { usuario = "admin", clave = "admin", nombre="Administrador", email = "micorreo@gmail.com" },
            new UserModel{ usuario = "user1", clave="12345", nombre="Usuario de prueba",email = "user1@gmail.com" } };

            foreach (UserModel usu in listaUsuarios)
            {
                if (usu.usuario == usuario && usu.clave == clave)
                {
                    return true; //Si el usuario y clave existen, se asignan todos sus valores.
                }
            }
            return false;
        }


    }
}
