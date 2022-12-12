using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;

namespace CapaPresentacionAdmin.Controllers
{
    //requerir login
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region Usuarios
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
        #endregion

        #region Reportes

        [HttpGet]
        public JsonResult ListaReporte(string fechainicio, string fechafin, string Idtransaccion)
        {
            List<Entidad_Reportes> oLista = new List<Entidad_Reportes>();

            oLista = new Negocio_Reporte().Ventas(fechainicio, fechafin, Idtransaccion);

            return Json(new { resultado = oLista }, JsonRequestBehavior.AllowGet);
        }  

        [HttpGet]
        public JsonResult VistaDashboard()
        {
            Entidad_DashBoard objeto = new Negocio_Reporte().VerDashBoard();
            return Json(new { resultado = objeto}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public FileResult ExportarVenta(string fechainicio, string fechafin, string Idtransaccion)
        {

            List<Entidad_Reportes> oLista = new List<Entidad_Reportes>();
            oLista = new Negocio_Reporte().Ventas(fechainicio, fechafin, Idtransaccion);

            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("Fecha Venta", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Prod_precio", typeof(decimal));
            dt.Columns.Add("DV_Cantidad", typeof(int));
            dt.Columns.Add("DV_Total", typeof(decimal));
            dt.Columns.Add("idTransaccion", typeof(string));


            foreach (Entidad_Reportes rp in oLista)
            {
                dt.Rows.Add(new object[] {
                    rp.Ven_fechaVenta,
                    rp.Cliente,
                    rp.Prod_nombre,
                    rp.Prod_precio,
                    rp.DV_Cantidad,
                    rp.DV_Total,
                    rp.IdTransaccion
                });
            }


                dt.TableName = "Datos";

                using (XLWorkbook wb = new XLWorkbook())
                {

                    wb.Worksheets.Add(dt);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteVenta" + DateTime.Now.ToString() + ".xlsx");

                    }
                }
            
        }

        #endregion
    }
}