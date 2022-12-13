using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CapaPresentacionCliente.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetalleProducto(int idProducto = 0)
        {

            Entidad_Producto oProducto = new Entidad_Producto();
            bool conversion;
            oProducto = new Negocio_Producto().Listar().Where(p => p.idProducto == idProducto).FirstOrDefault();
            if (oProducto != null)
            {
                oProducto.Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oProducto.Prod_rutaImagen, oProducto.Prod_nombreImagen), out conversion);
                oProducto.Extension = Path.GetExtension(oProducto.Prod_nombreImagen);
            }
            return View(oProducto);
        }

        [HttpGet]
        public JsonResult ListaCategorias()
        {
            List<Entidad_Categoria> lista = new List<Entidad_Categoria>();
            lista = new Negocio_Categoria().Listar();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarMarcaporCategoria(int idcategoria)
        {
            List<Entidad_Marca> lista = new List<Entidad_Marca>();
            lista = new Negocio_Marca().ListarMarcaporCategoria(idcategoria);
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarProducto(int idcategoria, int idmarca)
        {
            List<Entidad_Producto> lista = new List<Entidad_Producto>();

            bool conversion;

            lista = new Negocio_Producto().Listar().Select(p => new Entidad_Producto()
            {
                idProducto = p.idProducto,
                Prod_nombre = p.Prod_nombre,
                Prod_descripcion = p.Prod_descripcion,
                oMarca = p.oMarca,
                oCategoria = p.oCategoria,
                Prod_precio = p.Prod_precio,
                Prod_stock = p.Prod_stock,
                Prod_rutaImagen = p.Prod_rutaImagen,
                Base64 = CN_Recursos.ConvertirBase64(Path.Combine(p.Prod_rutaImagen, p.Prod_nombreImagen), out conversion),
                Extension = Path.GetExtension(p.Prod_nombreImagen),
                Prod_estado = p.Prod_estado
            }).Where(p =>
                p.oCategoria.idCategoria == (idcategoria == 0 ? p.oCategoria.idCategoria : idcategoria) &&
                //si marca es 0 va a mostrar todas las marcas y sino, va a mostrar solo por el parametro asignado
                p.oMarca.idMarca == (idmarca == 0 ? p.oMarca.idMarca : idmarca) &&
                p.Prod_stock > 0 && p.Prod_estado == true
            ).ToList();

            var jsonresult = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;
        }

        [HttpPost]
        public JsonResult AgregarCarrito(int idproducto)
        {
            int idcliente = ((Entidad_Cliente)Session["Cliente"]).idCliente;
            bool existe = new Negocio_Carrito().ExistCarrito(idcliente, idproducto);

            bool respuesta = false;
            string mensaje = string.Empty;
            if (existe)
            {
                mensaje = "El producto ya existe en el carrito";
            }
            else
            {
                respuesta = new Negocio_Carrito().OperacionCarrito(idcliente, idproducto, true, out mensaje);
            }
            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CantidadEnCarrito()
        {
            int idcliente = ((Entidad_Cliente)Session["Cliente"]).idCliente;
            int cantidad = new Negocio_Carrito().CantidadEnCarrito(idcliente);
            return Json(new { Car_cantidad = cantidad }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ListarProductosCarrito()
        {
            int idcliente = ((Entidad_Cliente)Session["Cliente"]).idCliente;
            List<Entidad_Carrito> oLista = new List<Entidad_Carrito>();
            bool conversion;
            oLista = new Negocio_Carrito().ListarProducto(idcliente).Select(oc => new Entidad_Carrito()
            {
                oProducto = new Entidad_Producto()
                {
                    idProducto = oc.oProducto.idProducto,
                    Prod_nombre = oc.oProducto.Prod_nombre,
                    oMarca = oc.oProducto.oMarca,
                    Prod_precio = oc.oProducto.Prod_precio,
                    Prod_rutaImagen = oc.oProducto.Prod_rutaImagen,
                    Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oc.oProducto.Prod_rutaImagen, oc.oProducto.Prod_nombreImagen), out conversion),
                    Extension = Path.GetExtension(oc.oProducto.Prod_nombreImagen)
                },
                Car_cantidad = oc.Car_cantidad
            }).ToList();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult OperacionCarrito(int idproducto, bool sumar)
        {
            int idcliente = ((Entidad_Cliente)Session["Cliente"]).idCliente;

            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new Negocio_Carrito().OperacionCarrito(idcliente, idproducto, true, out mensaje);
            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCarrito(int idproducto)
        {
            int idcliente = ((Entidad_Cliente)Session["Cliente"]).idCliente;

            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new Negocio_Carrito().EliminarCarrito(idcliente, idproducto);
            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Carrito()
        {
            return View();
        }
    }
}