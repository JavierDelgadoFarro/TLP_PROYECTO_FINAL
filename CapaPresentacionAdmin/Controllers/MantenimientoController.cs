using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace CapaPresentacionAdmin.Controllers
{
    //requerir login
    [Authorize]
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
        #region CONTROLADOR PARA CATEGORIA
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
#endregion

        /*MARCA*/
        #region CONTROLADOR PARA MARCA
        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<Entidad_Marca> oLista = new List<Entidad_Marca>();
            oLista = new Negocio_Marca().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMarca(Entidad_Marca objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.idMarca == 0)
            {
                resultado = new Negocio_Marca().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new Negocio_Marca().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new Negocio_Marca().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
#endregion


        /*PRODUCTO*/
        #region CONTROLADOR PARA PRODUCTO

        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<Entidad_Producto> oLista = new List<Entidad_Producto>();
            oLista = new Negocio_Producto().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProducto(string objeto, HttpPostedFileBase archivoImagen)
        {
            string mensaje = string.Empty;

            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;

            Entidad_Producto oProducto = new Entidad_Producto();
            //convertir string en un objeto producto
            oProducto = JsonConvert.DeserializeObject <Entidad_Producto>(objeto);
            decimal precio;
            if (decimal.TryParse(oProducto.PrecioTexto, NumberStyles.AllowDecimalPoint, new CultureInfo("es-PE"), out precio))
            {
                oProducto.Prod_precio = precio;
            }
            else
            {
                return Json(new { operacion_exitosa = false, mensaje = "El formato del precio debe ser ##.##" }, JsonRequestBehavior.AllowGet);
            }
            if (oProducto.idProducto == 0)
            {
                int idProductoGenerado = new Negocio_Producto().Registrar(oProducto, out mensaje);
                if (idProductoGenerado != 0) {
                    oProducto.idProducto = idProductoGenerado;
                }
                else
                {
                    operacion_exitosa = false;
                }
            }
            else
            {
                operacion_exitosa = new Negocio_Producto().Editar(oProducto, out mensaje);
            }
            if (operacion_exitosa)
            {
                if(archivoImagen != null)
                {
                    string ruta_guardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    //se guarda el id del producto y su extension
                    string nombre_imagen = string.Concat(oProducto.idProducto.ToString(),extension);
                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar,nombre_imagen));
                    }catch(Exception ex)
                    {
                        string msg = ex.Message;
                        guardar_imagen_exito = false;
                    }
                    if (guardar_imagen_exito)
                    {
                        oProducto.Prod_rutaImagen = ruta_guardar;
                        oProducto.Prod_nombreImagen = nombre_imagen;
                        bool respuesta = new Negocio_Producto().GuardarDatosImagen(oProducto, out mensaje);
                    }
                    else
                    {
                        mensaje = "Se guardó el producto pero hubo problemas con la imagen";
                    }
                }
            }
            return Json(new { operacion_exitosa = operacion_exitosa,idGenerado = oProducto.idProducto, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ImagenProducto(int id)
        {

            bool conversion;
            Entidad_Producto oproducto = new Negocio_Producto().Listar().Where(p => p.idProducto == id).FirstOrDefault();

            string textoBase64 = CN_Recursos.ConvertirBase64(Path.Combine(oproducto.Prod_rutaImagen, oproducto.Prod_nombreImagen), out conversion);


            return Json(new
            {
                conversion = conversion,
                textobase64 = textoBase64,
                extension = Path.GetExtension(oproducto.Prod_nombreImagen)

            },
             JsonRequestBehavior.AllowGet
            );


        }

        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new Negocio_Producto().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
    #endregion
}