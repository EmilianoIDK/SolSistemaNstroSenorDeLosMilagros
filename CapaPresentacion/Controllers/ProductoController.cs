using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CapaEntidades;
using CapaAplicación;

namespace CapaPresentacion.Controllers
{
    public class ProductoController : Controller
    {
        [Filtro.SesionIntranetController]
        [HttpGet]
        // Lista
        public ActionResult Lista(string msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entProducto> lista = logProducto.Instancia.ListarProductos();
                return View(lista);
            }
            catch (Exception e)
            {
                return RedirectToAction("MenuPrincipal", "Intranet", new { msg = "Ocurrió un error inesperado." });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Insertar
        public ActionResult Insertar(string msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Producto", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Insertar(FormCollection formulario)
        {
            try
            {
                bool inserto = false;
                entProducto p = new entProducto();
                p.nombre = Convert.ToString(formulario["nombre"]);
                p.marca = Convert.ToString(formulario["marca"]);
                p.precio = Convert.ToDecimal(formulario["precio"]);
                p.cantidad = Convert.ToInt32(formulario["cantidad"]);
                p.vencimiento = Convert.ToString(formulario["vencimiento"]);
                p.estado = Convert.ToBoolean(formulario["estado"]);

                inserto = logProducto.Instancia.InsertarProducto(p);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Producto");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Producto", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Editar
        public ActionResult Editar(int idProducto)
        {
            try
            {
                entProducto p = logProducto.Instancia.BuscarProducto(idProducto);
                return View(p);
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Producto", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Editar(FormCollection formulario)
        {
            try
            {
                bool actualizo = false;
                entProducto p = new entProducto();
                p.idProducto = Convert.ToInt32(formulario["idProducto"]);
                p.nombre = Convert.ToString(formulario["nombre"]);
                p.marca = Convert.ToString(formulario["marca"]);
                p.precio = Convert.ToDecimal(formulario["precio"]);
                p.cantidad = Convert.ToInt32(formulario["cantidad"]);
                p.vencimiento = Convert.ToString(formulario["vencimiento"]);
                p.estado = Convert.ToBoolean(formulario["estado"]);

                actualizo = logProducto.Instancia.EditarProducto(p);
                if (actualizo)
                {
                    return RedirectToAction("Lista", "Producto");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Producto", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Eliminar
        public ActionResult Eliminar(int idProducto)
        {
            try
            {
                bool elimino = logProducto.Instancia.EliminarProducto(idProducto);
                if (elimino)
                {
                    return RedirectToAction("Lista", "Producto");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Producto", new { msg = e.Message });
            }
        }
    }
}
