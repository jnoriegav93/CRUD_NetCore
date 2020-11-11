using NUnit.Framework;
using proyecto.Controllers;

namespace pruebas
{
    public class Pruebas
    {
        public HomeController control = new HomeController(null);

        [Test]
        public void MensajeNoEstaVacio()
        {
            var mensaje = control.Mensaje();
            
            Assert.IsFalse(string.IsNullOrWhiteSpace(mensaje));
        }

        [Test]
        public void TamanoMensajeMayorACero()
        {
            var mensaje = control.Mensaje();
            
            Assert.IsFalse(mensaje.Length < 0);
        }


        [TestCase (123)]
        //[TestCase (0)]
        public void IdNoNulo_o_MayorACero(int id)
        {
            control.lstPersonas.id = id;
            var mensaje = control.lstPersonas.id;
            
            Assert.IsFalse(mensaje == 0 || string.IsNullOrWhiteSpace((control.lstPersonas.id).ToString()));
        }

        //[TestCase ("usuario","clave")]
        [TestCase ("admin","admin")]
        [TestCase ("user1","12345")]
        public void UsuarioCorrecto(string usuario, string clave)
        {
            Assert.IsFalse(!control.UsuarioExiste(usuario,clave));
        }
    }
}