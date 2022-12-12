using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacionAdmin.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CambiarClave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Entidad_Usuario oUsuario = new Entidad_Usuario();

            oUsuario = new Negocio_Usuario().Listar().Where(u => u.Usu_correo == correo && u.Usu_password == CN_Recursos.ConvertirSha256(clave)).FirstOrDefault();


            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            }
            else
            {
                //primer ingreso requiere cambiar clave
                if (oUsuario.Usu_reestablecer)
                {
                    TempData["idUsuario"] = oUsuario.idUsuario;
                    return RedirectToAction("CambiarClave");
                }
                FormsAuthentication.SetAuthCookie(oUsuario.Usu_correo, false);
                ViewBag.Error = null;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult CambiarClave(string idusuario, string claveactual, string nuevaclave, string confirmarclave)
        {

            Entidad_Usuario oUsuario = new Entidad_Usuario();

            oUsuario = new Negocio_Usuario().Listar().Where(u => u.idUsuario == int.Parse(idusuario)).FirstOrDefault();

            if (oUsuario.Usu_password != CN_Recursos.ConvertirSha256(claveactual))
            {
                TempData["idUsuario"] = idusuario;
                ViewData["vclave"] = "";
                ViewBag.Error = "La contraseña actual no es correcta";
                return View();
            }
            else if (nuevaclave != confirmarclave)
            {

                TempData["idUsuario"] = idusuario;
                ViewData["vclave"] = claveactual;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }
            ViewData["vclave"] = "";

            nuevaclave = CN_Recursos.ConvertirSha256(nuevaclave);

            string mensaje = string.Empty;

            bool respuesta = new Negocio_Usuario().CambiarClave(int.Parse(idusuario), nuevaclave, out mensaje);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["idUsuario"] = idusuario;
                ViewBag.Error = mensaje;
                return View();
            }

        }
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");

        }
    }
}