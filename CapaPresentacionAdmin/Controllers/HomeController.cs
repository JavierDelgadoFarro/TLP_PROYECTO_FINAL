using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Entidad_Usuario> oLista = new List<Entidad_Usuario>();
            oLista = new Negocio_Usuario().Listar();

            return Json( new { data = oLista },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Entidad_Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.idUsuario == 0)
            {
                //int
                resultado = new Negocio_Usuario().Registrar(objeto, out mensaje);
            }
            else
            {
                //boolean
                resultado = new Negocio_Usuario().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new Negocio_Usuario().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}