using System;
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


    }
}