using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Empleados()
        {
            return View();
        }

        public ActionResult Marcas()
        {
            return View();
        }
        public ActionResult Categorias()
        {
            return View();
        }
        public ActionResult Productos()
        {
            return View();
        }

        /*CATEGORIA*/

        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<Entidad_Categoria> oLista = new List<Entidad_Categoria>();
            oLista = new Negocio_Categoria().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Entidad_Categoria objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.idCategoria == 0)
            {
                resultado = new Negocio_Categoria().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new Negocio_Categoria().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new Negocio_Categoria().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}