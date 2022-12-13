using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionCliente.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Entidad_Cliente objeto)
        {
            int resultado;
            string mensaje = string.Empty;

            ViewData["Nombres"] = string.IsNullOrEmpty(objeto.Cli_nombres) ? "" : objeto.Cli_nombres;
            ViewData["Apellido"] = string.IsNullOrEmpty(objeto.Cli_apellidos) ? "" : objeto.Cli_apellidos;
            ViewData["Correo"] = string.IsNullOrEmpty(objeto.Cli_correo) ? "" : objeto.Cli_correo;

            if(objeto.Cli_password != objeto.Cli_confirmarPass)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            resultado = new Negocio_Cliente().Registrar(objeto, out mensaje);

            if(resultado > 0)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }


        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Entidad_Cliente oCliente = null;

            oCliente = new Negocio_Cliente().Listar().Where(item => item.Cli_correo == correo && item.Cli_password == CN_Recursos.ConvertirSha256(clave)).FirstOrDefault();

            if(oCliente == null)
            {
                ViewBag.Error = "Correo o contraseña no son correctas";
                return View();
            }
            else
            {
                if (oCliente.Cli_reestablecer)
                {
                    TempData["idCliente"] = oCliente.idCliente;
                    return RedirectToAction("CambiarClave", "Acceso");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(oCliente.Cli_correo, false);
                    Session["Cliente"] = oCliente;
                    ViewBag.Error = null;
                    return RedirectToAction("Index", "Tienda");
                }
            }
        }

        [HttpPost]

        public ActionResult CambiarClave(string idcliente, string claveactual, string nuevaclave, string confirmarclave )
        {
            Entidad_Cliente oCliente = new Entidad_Cliente();

            oCliente = new Negocio_Cliente().Listar().Where(c => c.idCliente == int.Parse(idcliente)).FirstOrDefault();

            if (oCliente.Cli_password != CN_Recursos.ConvertirSha256(claveactual))
            {
                TempData["idCliente"] = idcliente;
                ViewData["vclave"] = "";
                ViewBag.Error = "La contraseña actual no es correcta";
                return View();
            }
            else if (nuevaclave != confirmarclave)
            {

                TempData["idCliente"] = idcliente;
                ViewData["vclave"] = claveactual;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }
            ViewData["vclave"] = "";

            nuevaclave = CN_Recursos.ConvertirSha256(nuevaclave);

            string mensaje = string.Empty;

            bool respuesta = new Negocio_Cliente().CambiarClave(int.Parse(idcliente), nuevaclave, out mensaje);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["idCliente"] = idcliente;
                ViewBag.Error = mensaje;
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            Session["Cliente"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");

        }
    }

}