using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaAplicación;

namespace CapaPresentacion.Controllers
{
    public class ClienteController : Controller
    {
        [Filtro.SesionIntranetController]
        [HttpGet]
        // Lista
        public ActionResult Lista(string msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entCliente> lista = logCliente.Instancia.ListarClientes();
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
                return RedirectToAction("Lista", "Cliente", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Insertar(entCliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool inserto = logCliente.Instancia.InsertarCliente(cliente);
                    if (inserto)
                    {
                        TempData["Mensaje"] = "Cliente insertado exitosamente.";
                        return RedirectToAction("Lista", "Cliente");
                    }
                    else
                    {
                        TempData["Mensaje"] = "Error al insertar el cliente.";
                        return View(cliente);
                    }
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Editar (GET)
        public ActionResult Editar(int idCliente)
        {
            try
            {
                entCliente cliente = logCliente.Instancia.BuscarCliente(idCliente);
                if (cliente == null)
                {
                    TempData["Mensaje"] = "Cliente no encontrado.";
                    return RedirectToAction("Lista", "Cliente");
                }
                return View(cliente);
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Editar(entCliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool actualizo = logCliente.Instancia.EditarCliente(cliente);
                    if (actualizo)
                    {
                        TempData["Mensaje"] = "Cliente actualizado exitosamente.";
                        return RedirectToAction("Lista", "Cliente");
                    }
                    else
                    {
                        TempData["Mensaje"] = "Error al actualizar el cliente.";
                        return View(cliente);
                    }
                }
                return View(cliente);
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Eliminar
        public ActionResult Eliminar(int idCliente)
        {
            try
            {
                bool elimino = logCliente.Instancia.EliminarCliente(idCliente);
                if (elimino)
                {
                    TempData["Mensaje"] = "Cliente eliminado exitosamente.";
                    return RedirectToAction("Lista", "Cliente");
                }
                else
                {
                    TempData["Mensaje"] = "No se pudo eliminar el cliente.";
                    return RedirectToAction("Lista", "Cliente");
                }
            }
            catch (Exception e)
            {
                TempData["Mensaje"] = "Ocurrió un error al eliminar el cliente.";
                return RedirectToAction("Lista", "Cliente", new { msg = e.Message });
            }
        }
    }
}
